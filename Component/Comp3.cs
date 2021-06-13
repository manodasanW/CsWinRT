﻿using ABI.Component;
using Component;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using WinRT;
using WinRT.Interop;

/*
 * Original code for the below hand rolled projection to demonstrate what the generated code and changes would look like and to validate it.
 * Original components implements interface, has overloaded constructor and static functions. 
 * 
  namespace Component
  {

   public interface ITest
   {
       int GetTest();
   }

   public class Comp3 : ITest
   {
       public Comp3()
       {
           _num = 5;
       }

       public Comp3(int num)
       {
           _num = num;
       }

       static Int32 GetNum2Multiplier()
       {
            return 2;
       }

       static Comp3 GetComp12()
       {
            return new Comp3(12);
       }

       public int GetNumber()
       {
           return _num;
       }

       public int GetNumber2()
       {
           return _num * 2;
       }

       public int GetTest
       {
           return _num * 3;
       }

       private int _num;
    }
  }
 * 
 * An IDL / WinMD which would be auto generated would look something like the following.
 * 
   namespace Component
   {
       interface ITest
       {
           Int32 GetTest();
       }

       runtimeclass Comp3 : ITest
       {
           Comp3();
           Comp3(Int32 num);

           static Int32 GetNum2Multiplier();
           static Comp3 GetComp12();

           Int32 GetNumber();
           Int32 GetNumber2();
       }
   }
 */

namespace Component
{
    // Note this hand rolled projection is a bit different where the original component is
    // not renamed, but is still regenerated to implement the default interface.
    // This projection is an optimized version such that C# callers don't need to go through
    // a projection, but are interacting with the component directly.
    // Need to investigate where there is anything else we need to handle that the CsWinRT projected class handles.
    public class Comp3 : global::Component.IComp3, global::Component.ITest
    {
        public Comp3()
        {
            _num = 8;
        }

        public Comp3(int num)
        {
            _num = num;
        }

        public static int GetNum2Multiplier()
        {
            return 2;
        }

        // Function added to component code, but note we are no longer dealing with
        // whether it is the server object or the projected object like we do in Comp2.
        internal static Comp3 FromAbi(IntPtr thisPtr)
        {
            if (thisPtr == IntPtr.Zero) return null;
            var obj = MarshalInspectable.FromAbi(thisPtr);
            return obj is Comp3 ? (Comp3)obj : null;
        }

        public static Comp3 GetComp12()
        {
            return new Comp3(12);
        }

        public int GetNumber()
        {
            return _num;
        }

        public int GetNumber2()
        {
            return _num * 2;
        }

        public int GetTest()
        {
            return _num * 3;
        }

        private int _num;
    }
}

#pragma warning disable 0169 // warning CS0169: The field '...' is never used
#pragma warning disable 0649 // warning CS0169: Field '...' is never assigned to

namespace Component
{

    [global::WinRT.WindowsRuntimeType]
    [Guid("0B7AC6A9-A869-55E6-9828-AAA82370766F")]
    [Windows.Foundation.Metadata.ExclusiveTo(typeof(Comp3))]
    [Windows.Foundation.Metadata.Version(1u)]
    internal interface IComp3
    {
        int GetNumber();
        int GetNumber2();
    }
    [global::WinRT.WindowsRuntimeType]
    [Guid("01657682-5E84-59E4-97D4-7E3A704EB078")]
    [Windows.Foundation.Metadata.ExclusiveTo(typeof(Comp3))]
    [Windows.Foundation.Metadata.Version(1u)]
    internal interface IComp3Factory
    {
        Comp3 CreateInstance(int num);
    }
    [global::WinRT.WindowsRuntimeType]
    [Guid("CF54A495-6641-5C60-94E7-438846BFB877")]
    [Windows.Foundation.Metadata.ExclusiveTo(typeof(Comp3))]
    [Windows.Foundation.Metadata.Version(1u)]
    internal interface IComp3Statics
    {
        int GetNum2Multiplier();
        Comp3 GetComp12();
    }

    // Note that this interface would be part of the original component's code,
    // but we generate a new one as we need attributes on it.
    // Note I already generated it in Comp2, so it is commented out.
    /*
    [global::WinRT.WindowsRuntimeType]
    [Guid("D21205D2-44FF-5128-A1BF-BD20A0F42C1A")]
    [Windows.Foundation.Metadata.Version(1u)]
    public interface ITest
    {
        int GetTest();
    }
    */
}

namespace ABI.Component
{
    // Generated code from CsWinRT

    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public struct Comp3
    {
        public static IObjectReference CreateMarshaler(global::Component.Comp3 obj) => obj is null ? null : MarshalInspectable.CreateMarshaler(obj).As<IComp3.Vftbl>();
        public static IntPtr GetAbi(IObjectReference value) => value is null ? IntPtr.Zero : MarshalInterfaceHelper<object>.GetAbi(value);
        public static global::Component.Comp3 FromAbi(IntPtr thisPtr) => global::Component.Comp3.FromAbi(thisPtr);
        public static IntPtr FromManaged(global::Component.Comp3 obj) => obj is null ? IntPtr.Zero : CreateMarshaler(obj).GetRef();
        public static unsafe MarshalInterfaceHelper<global::Component.Comp3>.MarshalerArray CreateMarshalerArray(global::Component.Comp3[] array) => MarshalInterfaceHelper<global::Component.Comp3>.CreateMarshalerArray(array, (o) => CreateMarshaler(o));
        public static (int length, IntPtr data) GetAbiArray(object box) => MarshalInterfaceHelper<global::Component.Comp3>.GetAbiArray(box);
        public static unsafe global::Component.Comp3[] FromAbiArray(object box) => MarshalInterfaceHelper<global::Component.Comp3>.FromAbiArray(box, FromAbi);
        public static (int length, IntPtr data) FromManagedArray(global::Component.Comp3[] array) => MarshalInterfaceHelper<global::Component.Comp3>.FromManagedArray(array, (o) => FromManaged(o));
        public static void DisposeMarshaler(IObjectReference value) => MarshalInspectable.DisposeMarshaler(value);
        public static void DisposeMarshalerArray(MarshalInterfaceHelper<global::Component.Comp3>.MarshalerArray array) => MarshalInterfaceHelper<global::Component.Comp3>.DisposeMarshalerArray(array);
        public static void DisposeAbi(IntPtr abi) => MarshalInspectable.DisposeAbi(abi);
        public static unsafe void DisposeAbiArray(object box) => MarshalInspectable.DisposeAbiArray(box);
    }

    [global::WinRT.ObjectReferenceWrapper(nameof(_obj))]
    [Guid("0B7AC6A9-A869-55E6-9828-AAA82370766F")]
    public class IComp3 : global::Component.IComp3
    {
        [Guid("0B7AC6A9-A869-55E6-9828-AAA82370766F")]
        public struct Vftbl
        {
            internal IInspectable.Vftbl IInspectableVftbl;
            public IComp3_Delegates.GetNumber_0 GetNumber_0;
            public IComp3_Delegates.GetNumber2_1 GetNumber2_1;

            private static readonly Vftbl AbiToProjectionVftable;
            public static readonly IntPtr AbiToProjectionVftablePtr;
            static unsafe Vftbl()
            {
                AbiToProjectionVftable = new Vftbl
                {
                    IInspectableVftbl = global::WinRT.IInspectable.Vftbl.AbiToProjectionVftable,
                    GetNumber_0 = Do_Abi_GetNumber_0,
                    GetNumber2_1 = Do_Abi_GetNumber2_1
                };
                var nativeVftbl = (IntPtr*)ComWrappersSupport.AllocateVtableMemory(typeof(Vftbl), Marshal.SizeOf<global::WinRT.IInspectable.Vftbl>() + sizeof(IntPtr) * 2);
                Marshal.StructureToPtr(AbiToProjectionVftable, (IntPtr)nativeVftbl, false);
                AbiToProjectionVftablePtr = (IntPtr)nativeVftbl;
            }

            private static unsafe int Do_Abi_GetNumber_0(IntPtr thisPtr, out int result)
            {
                int __result = default;

                result = default;

                try
                {
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.IComp3>(thisPtr).GetNumber();
                    result = __result;

                }
                catch (Exception __exception__)
                {
                    global::WinRT.ExceptionHelpers.SetErrorInfo(__exception__);
                    return global::WinRT.ExceptionHelpers.GetHRForException(__exception__);
                }
                return 0;
            }
            private static unsafe int Do_Abi_GetNumber2_1(IntPtr thisPtr, out int result)
            {
                int __result = default;

                result = default;

                try
                {
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.IComp3>(thisPtr).GetNumber2();
                    result = __result;

                }
                catch (Exception __exception__)
                {
                    global::WinRT.ExceptionHelpers.SetErrorInfo(__exception__);
                    return global::WinRT.ExceptionHelpers.GetHRForException(__exception__);
                }
                return 0;
            }
        }
        internal static ObjectReference<Vftbl> FromAbi(IntPtr thisPtr) => ObjectReference<Vftbl>.FromAbi(thisPtr);

        public static implicit operator IComp3(IObjectReference obj) => (obj != null) ? new IComp3(obj) : null;
        protected readonly ObjectReference<Vftbl> _obj;
        public IObjectReference ObjRef { get => _obj; }
        public IntPtr ThisPtr => _obj.ThisPtr;
        public ObjectReference<I> AsInterface<I>() => _obj.As<I>();
        public A As<A>() => _obj.AsType<A>();
        public IComp3(IObjectReference obj) : this(obj.As<Vftbl>()) { }
        internal IComp3(ObjectReference<Vftbl> obj)
        {
            _obj = obj;
        }

        public unsafe int GetNumber()
        {
            int __retval = default;
            global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.GetNumber_0(ThisPtr, out __retval));
            return __retval;
        }

        public unsafe int GetNumber2()
        {
            int __retval = default;
            global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.GetNumber2_1(ThisPtr, out __retval));
            return __retval;
        }
    }
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public static class IComp3_Delegates
    {
        public unsafe delegate int GetNumber_0(IntPtr thisPtr, out int result);
        public unsafe delegate int GetNumber2_1(IntPtr thisPtr, out int result);
    }

    [global::WinRT.ObjectReferenceWrapper(nameof(_obj))]
    [Guid("01657682-5E84-59E4-97D4-7E3A704EB078")]
    public class IComp3Factory : global::Component.IComp3Factory
    {
        [Guid("01657682-5E84-59E4-97D4-7E3A704EB078")]
        public struct Vftbl
        {
            internal IInspectable.Vftbl IInspectableVftbl;
            public IComp3Factory_Delegates.CreateInstance_0 CreateInstance_0;

            private static readonly Vftbl AbiToProjectionVftable;
            public static readonly IntPtr AbiToProjectionVftablePtr;
            static unsafe Vftbl()
            {
                AbiToProjectionVftable = new Vftbl
                {
                    IInspectableVftbl = global::WinRT.IInspectable.Vftbl.AbiToProjectionVftable,
                    CreateInstance_0 = Do_Abi_CreateInstance_0
                };
                var nativeVftbl = (IntPtr*)ComWrappersSupport.AllocateVtableMemory(typeof(Vftbl), Marshal.SizeOf<global::WinRT.IInspectable.Vftbl>() + sizeof(IntPtr) * 1);
                Marshal.StructureToPtr(AbiToProjectionVftable, (IntPtr)nativeVftbl, false);
                AbiToProjectionVftablePtr = (IntPtr)nativeVftbl;
            }

            private static unsafe int Do_Abi_CreateInstance_0(IntPtr thisPtr, int num, out IntPtr value)
            {
                global::Component.Comp3 __value = default;

                value = default;

                try
                {
                    __value = global::WinRT.ComWrappersSupport.FindObject<global::Component.IComp3Factory>(thisPtr).CreateInstance(num);
                    value = global::ABI.Component.Comp3.FromManaged(__value);

                }
                catch (Exception __exception__)
                {
                    global::WinRT.ExceptionHelpers.SetErrorInfo(__exception__);
                    return global::WinRT.ExceptionHelpers.GetHRForException(__exception__);
                }
                return 0;
            }
        }
        internal static ObjectReference<Vftbl> FromAbi(IntPtr thisPtr) => ObjectReference<Vftbl>.FromAbi(thisPtr);

        public static implicit operator IComp3Factory(IObjectReference obj) => (obj != null) ? new IComp3Factory(obj) : null;
        protected readonly ObjectReference<Vftbl> _obj;
        public IObjectReference ObjRef { get => _obj; }
        public IntPtr ThisPtr => _obj.ThisPtr;
        public ObjectReference<I> AsInterface<I>() => _obj.As<I>();
        public A As<A>() => _obj.AsType<A>();
        public IComp3Factory(IObjectReference obj) : this(obj.As<Vftbl>()) { }
        internal IComp3Factory(ObjectReference<Vftbl> obj)
        {
            _obj = obj;
        }

        public unsafe global::Component.Comp3 CreateInstance(int num)
        {
            IntPtr __retval = default;
            try
            {
                global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.CreateInstance_0(ThisPtr, num, out __retval));
                return global::ABI.Component.Comp3.FromAbi(__retval);
            }
            finally
            {
                global::ABI.Component.Comp3.DisposeAbi(__retval);
            }
        }
    }
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public static class IComp3Factory_Delegates
    {
        public unsafe delegate int CreateInstance_0(IntPtr thisPtr, int num, out IntPtr value);
    }

    [global::WinRT.ObjectReferenceWrapper(nameof(_obj))]
    [Guid("CF54A495-6641-5C60-94E7-438846BFB877")]
    public class IComp3Statics : global::Component.IComp3Statics
    {
        [Guid("CF54A495-6641-5C60-94E7-438846BFB877")]
        public struct Vftbl
        {
            internal IInspectable.Vftbl IInspectableVftbl;
            public IComp3Statics_Delegates.GetNum2Multiplier_0 GetNum2Multiplier_0;
            public IComp3Statics_Delegates.GetComp12_1 GetComp12_1;

            private static readonly Vftbl AbiToProjectionVftable;
            public static readonly IntPtr AbiToProjectionVftablePtr;
            static unsafe Vftbl()
            {
                AbiToProjectionVftable = new Vftbl
                {
                    IInspectableVftbl = global::WinRT.IInspectable.Vftbl.AbiToProjectionVftable,
                    GetNum2Multiplier_0 = Do_Abi_GetNum2Multiplier_0,
                    GetComp12_1 = Do_Abi_GetComp12_1
                };
                var nativeVftbl = (IntPtr*)ComWrappersSupport.AllocateVtableMemory(typeof(Vftbl), Marshal.SizeOf<global::WinRT.IInspectable.Vftbl>() + sizeof(IntPtr) * 2);
                Marshal.StructureToPtr(AbiToProjectionVftable, (IntPtr)nativeVftbl, false);
                AbiToProjectionVftablePtr = (IntPtr)nativeVftbl;
            }

            private static unsafe int Do_Abi_GetNum2Multiplier_0(IntPtr thisPtr, out int result)
            {
                int __result = default;

                result = default;

                try
                {
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.IComp3Statics>(thisPtr).GetNum2Multiplier();
                    result = __result;

                }
                catch (Exception __exception__)
                {
                    global::WinRT.ExceptionHelpers.SetErrorInfo(__exception__);
                    return global::WinRT.ExceptionHelpers.GetHRForException(__exception__);
                }
                return 0;
            }
            private static unsafe int Do_Abi_GetComp12_1(IntPtr thisPtr, out IntPtr result)
            {
                global::Component.Comp3 __result = default;

                result = default;

                try
                {
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.IComp3Statics>(thisPtr).GetComp12();
                    result = global::ABI.Component.Comp3.FromManaged(__result);

                }
                catch (Exception __exception__)
                {
                    global::WinRT.ExceptionHelpers.SetErrorInfo(__exception__);
                    return global::WinRT.ExceptionHelpers.GetHRForException(__exception__);
                }
                return 0;
            }
        }
        internal static ObjectReference<Vftbl> FromAbi(IntPtr thisPtr) => ObjectReference<Vftbl>.FromAbi(thisPtr);

        public static implicit operator IComp3Statics(IObjectReference obj) => (obj != null) ? new IComp3Statics(obj) : null;
        protected readonly ObjectReference<Vftbl> _obj;
        public IObjectReference ObjRef { get => _obj; }
        public IntPtr ThisPtr => _obj.ThisPtr;
        public ObjectReference<I> AsInterface<I>() => _obj.As<I>();
        public A As<A>() => _obj.AsType<A>();
        public IComp3Statics(IObjectReference obj) : this(obj.As<Vftbl>()) { }
        internal IComp3Statics(ObjectReference<Vftbl> obj)
        {
            _obj = obj;
        }

        public unsafe int GetNum2Multiplier()
        {
            int __retval = default;
            global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.GetNum2Multiplier_0(ThisPtr, out __retval));
            return __retval;
        }

        public unsafe global::Component.Comp3 GetComp12()
        {
            IntPtr __retval = default;
            try
            {
                global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.GetComp12_1(ThisPtr, out __retval));
                return global::ABI.Component.Comp3.FromAbi(__retval);
            }
            finally
            {
                global::ABI.Component.Comp3.DisposeAbi(__retval);
            }
        }
    }
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public static class IComp3Statics_Delegates
    {
        public unsafe delegate int GetNum2Multiplier_0(IntPtr thisPtr, out int result);
        public unsafe delegate int GetComp12_1(IntPtr thisPtr, out IntPtr result);
    }

    // Already generated as part of Comp2, so commenting out here.
/*
    [global::WinRT.ObjectReferenceWrapper(nameof(_obj))]
    [Guid("D21205D2-44FF-5128-A1BF-BD20A0F42C1A")]
    public class ITest : global::Component.ITest
    {
        [Guid("D21205D2-44FF-5128-A1BF-BD20A0F42C1A")]
        public struct Vftbl
        {
            internal IInspectable.Vftbl IInspectableVftbl;
            public ITest_Delegates.GetTest_0 GetTest_0;

            private static readonly Vftbl AbiToProjectionVftable;
            public static readonly IntPtr AbiToProjectionVftablePtr;
            static unsafe Vftbl()
            {
                AbiToProjectionVftable = new Vftbl
                {
                    IInspectableVftbl = global::WinRT.IInspectable.Vftbl.AbiToProjectionVftable,
                    GetTest_0 = Do_Abi_GetTest_0
                };
                var nativeVftbl = (IntPtr*)ComWrappersSupport.AllocateVtableMemory(typeof(Vftbl), Marshal.SizeOf<global::WinRT.IInspectable.Vftbl>() + sizeof(IntPtr) * 1);
                Marshal.StructureToPtr(AbiToProjectionVftable, (IntPtr)nativeVftbl, false);
                AbiToProjectionVftablePtr = (IntPtr)nativeVftbl;
            }

            private static unsafe int Do_Abi_GetTest_0(IntPtr thisPtr, out int result)
            {
                int __result = default;

                result = default;

                try
                {
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.ITest>(thisPtr).GetTest();
                    result = __result;

                }
                catch (Exception __exception__)
                {
                    global::WinRT.ExceptionHelpers.SetErrorInfo(__exception__);
                    return global::WinRT.ExceptionHelpers.GetHRForException(__exception__);
                }
                return 0;
            }
        }
        internal static ObjectReference<Vftbl> FromAbi(IntPtr thisPtr) => ObjectReference<Vftbl>.FromAbi(thisPtr);

        public static implicit operator ITest(IObjectReference obj) => (obj != null) ? new ITest(obj) : null;
        protected readonly ObjectReference<Vftbl> _obj;
        public IObjectReference ObjRef { get => _obj; }
        public IntPtr ThisPtr => _obj.ThisPtr;
        public ObjectReference<I> AsInterface<I>() => _obj.As<I>();
        public A As<A>() => _obj.AsType<A>();
        public ITest(IObjectReference obj) : this(obj.As<Vftbl>()) { }
        internal ITest(ObjectReference<Vftbl> obj)
        {
            _obj = obj;
        }

        public unsafe int GetTest()
        {
            int __retval = default;
            global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.GetTest_0(ThisPtr, out __retval));
            return __retval;
        }
    }
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public static class ITest_Delegates
    {
        public unsafe delegate int GetTest_0(IntPtr thisPtr, out int result);
    }
*/

    // Will be generated for each component that is activatable and will also implement the statics and factory interfaces.
    public class Comp3ServerActivationFactory : ProductionActivationFactory<global::Component.Comp3>, global::Component.IComp3Factory, global::Component.IComp3Statics
    {
        // Static function, either consumed through another generated static function
        // which handles all classes in this dll or via winrthost directly.
        public static IntPtr Make()
        {
            using var marshaler = MarshalInspectable.CreateMarshaler(_factory).As<IActivationFactory.Vftbl>();
            return marshaler.GetRef();
        }

        static readonly Comp3ServerActivationFactory _factory = new Comp3ServerActivationFactory();
        public static ObjectReference<I> ActivateInstance<I>()
        {
            IntPtr instance = _factory.ActivateInstance();
            return ObjectReference<IInspectable.Vftbl>.Attach(ref instance).As<I>();
        }

        // Note we no longer need to convert to the projected type as the server is the proejcted
        // type for C# callers.
        public global::Component.Comp3 CreateInstance(int num)
        {
            return new global::Component.Comp3(num);
        }

        public int GetNum2Multiplier()
        {
            return global::Component.Comp3.GetNum2Multiplier();
        }

        // Note we no longer need to convert to the projected type as the server is the proejcted
        // type for C# callers.
        public global::Component.Comp3 GetComp12()
        {
            return global::Component.Comp3.GetComp12();
        }
    }
}