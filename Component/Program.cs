using ABI.Component;
using Component;
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
    }
}