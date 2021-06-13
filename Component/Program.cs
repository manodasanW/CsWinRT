﻿using ABI.Component;
using ABI.Component.Impl;
using Component;
using TestComponentCSharp;
using System;
using System.Diagnostics;
using WinRT;

// Consumer of component
public class Program
{
    static void Main(string[] args)
    {
        // Comp - basic component
        {
            // Consumption from vtable side (i.e. close to what it would look like in terms of interactions if C++ was consuming it).
            IntPtr activationPtr = CompServerActivationFactory.Make();
            var activationObjectRef = ObjectReference<ABI.Component.IActivationFactory.Vftbl>.FromAbi(activationPtr);
            activationObjectRef.Vftbl.ActivateInstance(activationObjectRef.ThisPtr, out IntPtr compPtr);
            var compObjectRef = ObjectReference<IInspectable.Vftbl>.Attach(ref compPtr).As<ABI.Component.IComp.Vftbl>();
            compObjectRef.Vftbl.GetNumber_0(compObjectRef.ThisPtr, out int result);
            Debug.Assert(result == 5);

            // Consumption from C# caller side.
            // Note the use of the projected Comp class from CsWinRT rather than the original.
            Component.Comp comp = new Component.Comp();
            result = comp.GetNumber();
            Debug.Assert(result == 5);
        }

        // Comp2 - demonstrate interface, factory, and statics
        {
            // Consumption from vtable side (i.e. close to what it would look like in terms of interactions if C++ was consuming it).
            IntPtr activationPtr = Comp2ServerActivationFactory.Make();
            var activationObjectRef = ObjectReference<ABI.Component.IActivationFactory.Vftbl>.FromAbi(activationPtr);
            activationObjectRef.Vftbl.ActivateInstance(activationObjectRef.ThisPtr, out IntPtr compPtr);
            var compObjectRef = ObjectReference<IInspectable.Vftbl>.Attach(ref compPtr).As<ABI.Component.IComp2.Vftbl>();
            compObjectRef.Vftbl.GetNumber_0(compObjectRef.ThisPtr, out int result);
            Debug.Assert(result == 8);
            compObjectRef.Vftbl.GetNumber2_1(compObjectRef.ThisPtr, out result);
            Debug.Assert(result == 16);
            var compObjectRefTest = compObjectRef.As<ABI.Component.ITest.Vftbl>();
            compObjectRefTest.Vftbl.GetTest_0(compObjectRef.ThisPtr, out result);
            Debug.Assert(result == 24);
            // Statics
            var compStatics = activationObjectRef.As<ABI.Component.IComp2Statics.Vftbl>();
            compStatics.Vftbl.GetNum2Multiplier_0(compStatics.ThisPtr, out result);
            Debug.Assert(result == 2);
            compStatics.Vftbl.GetComp12_1(compStatics.ThisPtr, out IntPtr comp12Ptr);
            var comp12ObjectRef = ObjectReference<ABI.Component.IComp2.Vftbl>.Attach(ref comp12Ptr);
            comp12ObjectRef.Vftbl.GetNumber_0(comp12ObjectRef.ThisPtr, out result);
            Debug.Assert(result == 12);
            // Factory
            var compFactory = activationObjectRef.As<ABI.Component.IComp2Factory.Vftbl>();
            compFactory.Vftbl.CreateInstance_0(compFactory.ThisPtr, 7, out IntPtr comp7Ptr);
            var comp7ObjectRef = ObjectReference<ABI.Component.IComp2.Vftbl>.Attach(ref comp7Ptr);
            comp7ObjectRef.Vftbl.GetNumber_0(comp7ObjectRef.ThisPtr, out result);
            Debug.Assert(result == 7);

            // Consumption from C# caller side.
            // Note the use of the projected Comp class from CsWinRT rather than the original.
            Component.Comp2 comp = new Component.Comp2();
            result = comp.GetNumber();
            Debug.Assert(result == 8);
            result = comp.GetNumber2();
            Debug.Assert(result == 16);
            result = comp.GetTest();
            Debug.Assert(result == 24);
            // Statics
            result = Component.Comp2.GetNum2Multiplier();
            Debug.Assert(result == 2);
            var comp12 = Component.Comp2.GetComp12();
            result = comp12.GetNumber();
            Debug.Assert(result == 12);
            // Factory
            var comp7 = new Component.Comp2(7);
            result = comp7.GetNumber();
            Debug.Assert(result == 7);
        }

        // Comp3 - demonstrate interface, factory, and statics with optimizations for C# consumption.
        {
            // Consumption from vtable side (i.e. close to what it would look like in terms of interactions if C++ was consuming it).
            IntPtr activationPtr = Comp3ServerActivationFactory.Make();
            var activationObjectRef = ObjectReference<ABI.Component.IActivationFactory.Vftbl>.FromAbi(activationPtr);
            activationObjectRef.Vftbl.ActivateInstance(activationObjectRef.ThisPtr, out IntPtr compPtr);
            var compObjectRef = ObjectReference<IInspectable.Vftbl>.Attach(ref compPtr).As<ABI.Component.IComp3.Vftbl>();
            compObjectRef.Vftbl.GetNumber_0(compObjectRef.ThisPtr, out int result);
            Debug.Assert(result == 8);
            compObjectRef.Vftbl.GetNumber2_1(compObjectRef.ThisPtr, out result);
            Debug.Assert(result == 16);
            var compObjectRefTest = compObjectRef.As<ABI.Component.ITest.Vftbl>();
            compObjectRefTest.Vftbl.GetTest_0(compObjectRef.ThisPtr, out result);
            Debug.Assert(result == 24);
            // Statics
            var compStatics = activationObjectRef.As<ABI.Component.IComp3Statics.Vftbl>();
            compStatics.Vftbl.GetNum2Multiplier_0(compStatics.ThisPtr, out result);
            Debug.Assert(result == 2);
            compStatics.Vftbl.GetComp12_1(compStatics.ThisPtr, out IntPtr comp12Ptr);
            var comp12ObjectRef = ObjectReference<ABI.Component.IComp3.Vftbl>.Attach(ref comp12Ptr);
            comp12ObjectRef.Vftbl.GetNumber_0(comp12ObjectRef.ThisPtr, out result);
            Debug.Assert(result == 12);
            // Factory
            var compFactory = activationObjectRef.As<ABI.Component.IComp3Factory.Vftbl>();
            compFactory.Vftbl.CreateInstance_0(compFactory.ThisPtr, 7, out IntPtr comp7Ptr);
            var comp7ObjectRef = ObjectReference<ABI.Component.IComp3.Vftbl>.Attach(ref comp7Ptr);
            comp7ObjectRef.Vftbl.GetNumber_0(comp7ObjectRef.ThisPtr, out result);
            Debug.Assert(result == 7);

            // Consumption from C# caller side.
            // Note the use of the original server component rather than a wrapper projected component.
            Component.Comp3 comp = new Component.Comp3();
            result = comp.GetNumber();
            Debug.Assert(result == 8);
            result = comp.GetNumber2();
            Debug.Assert(result == 16);
            result = comp.GetTest();
            Debug.Assert(result == 24);
            // Statics
            result = Component.Comp3.GetNum2Multiplier();
            Debug.Assert(result == 2);
            var comp12 = Component.Comp3.GetComp12();
            result = comp12.GetNumber();
            Debug.Assert(result == 12);
            // Factory
            var comp7 = new Component.Comp3(7);
            result = comp7.GetNumber();
            Debug.Assert(result == 7);
        }

        // Comp4 - demonstrate interface, factory, and statics with no user code modification.
        {
            // Consumption from vtable side (i.e. close to what it would look like in terms of interactions if C++ was consuming it).
            IntPtr activationPtr = Comp4ServerActivationFactory.Make();
            var activationObjectRef = ObjectReference<ABI.Component.IActivationFactory.Vftbl>.FromAbi(activationPtr);
            activationObjectRef.Vftbl.ActivateInstance(activationObjectRef.ThisPtr, out IntPtr compPtr);
            var compObjectRef = ObjectReference<IInspectable.Vftbl>.Attach(ref compPtr).As<ABI.Component.Impl.IComp4.Vftbl>();
            compObjectRef.Vftbl.GetNumber_0(compObjectRef.ThisPtr, out int result);
            Debug.Assert(result == 8);
            compObjectRef.Vftbl.GetNumber2_1(compObjectRef.ThisPtr, out result);
            Debug.Assert(result == 16);
            var compObjectRefTest = compObjectRef.As<ABI.Component.Impl.ITest4.Vftbl>();
            compObjectRefTest.Vftbl.GetTest_0(compObjectRef.ThisPtr, out result);
            Debug.Assert(result == 24);
            // Statics
            var compStatics = activationObjectRef.As<ABI.Component.Impl.IComp4Statics.Vftbl>();
            compStatics.Vftbl.GetNum2Multiplier_0(compStatics.ThisPtr, out result);
            Debug.Assert(result == 2);
            compStatics.Vftbl.GetComp12_1(compStatics.ThisPtr, out IntPtr comp12Ptr);
            var comp12ObjectRef = ObjectReference<ABI.Component.Impl.IComp4.Vftbl>.Attach(ref comp12Ptr);
            comp12ObjectRef.Vftbl.GetNumber_0(comp12ObjectRef.ThisPtr, out result);
            Debug.Assert(result == 12);
            // Factory
            var compFactory = activationObjectRef.As<ABI.Component.Impl.IComp4Factory.Vftbl>();
            compFactory.Vftbl.CreateInstance_0(compFactory.ThisPtr, 7, out IntPtr comp7Ptr);
            var comp7ObjectRef = ObjectReference<ABI.Component.Impl.IComp4.Vftbl>.Attach(ref comp7Ptr);
            comp7ObjectRef.Vftbl.GetNumber_0(comp7ObjectRef.ThisPtr, out result);
            Debug.Assert(result == 7);
            // IWwwFormUrlDecoderEntry
            var wwwFormObjectEntry = compObjectRef.As<ABI.Windows.Foundation.IWwwFormUrlDecoderEntry.Vftbl>();
            wwwFormObjectEntry.Vftbl.get_Name_0(wwwFormObjectEntry.ThisPtr, out IntPtr stringPtr);
            var str = MarshalString.FromAbi(stringPtr);
            Debug.Assert(str == "8");
            wwwFormObjectEntry.Vftbl.get_Value_1(wwwFormObjectEntry.ThisPtr, out stringPtr);
            str = MarshalString.FromAbi(stringPtr);
            Debug.Assert(str == "16");
            // List
            compObjectRef.Vftbl.GetList_2(compObjectRef.ThisPtr, out IntPtr listPtr);
            var list = global::ABI.System.Collections.Generic.IList<global::Component.Comp5>.FromAbi(listPtr);
            Debug.Assert(list.Count == 1);
            Debug.Assert(list[0].GetPoint().X == 8);
            compObjectRef.Vftbl.GetList_2(compObjectRef.ThisPtr, out listPtr);
            list = global::ABI.System.Collections.Generic.IList<global::Component.Comp5>.FromAbi(listPtr);
            Debug.Assert(list.Count == 2);

            // Consumption from C# caller side.
            // Note the use of the original component rather than a wrapper projected component.
            Component.Comp4 comp = new Component.Comp4();
            result = comp.GetNumber();
            Debug.Assert(result == 8);
            result = comp.GetNumber2();
            Debug.Assert(result == 16);
            result = comp.GetTest();
            Debug.Assert(result == 24);
            // Statics
            result = Component.Comp4.GetNum2Multiplier();
            Debug.Assert(result == 2);
            var comp12 = Component.Comp4.GetComp12();
            result = comp12.GetNumber();
            Debug.Assert(result == 12);
            // Factory
            var comp7 = new Component.Comp4(7);
            result = comp7.GetNumber();
            Debug.Assert(result == 7);
            // IWwwFormUrlDecoderEntry
            str = comp.Name;
            Debug.Assert(str == "8");
            str = comp.Value;
            Debug.Assert(str == "16");

            // Use C++/WinRT component to consume component and validate string constructed with results of function calls
            Class cppClass = new Class();
            str = cppClass.MergeEntry(comp);
            Debug.Assert(str == "81624816");

            str = cppClass.TestComp(IInspectable.FromAbi(activationPtr));
            Debug.Assert(str == "4212212");
        }

    }
}