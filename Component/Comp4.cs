using ABI.Component;
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
 * 
 * An IDL / WinMD which would be auto generated for the below user code would look something like the following.
 * 
   namespace Component
   {
       interface ITest4
       {
           Int32 GetTest();
       }

       runtimeclass Comp4 : ITest4
       {
           Comp4();
           Comp4(Int32 num);

           static Int32 GetNum2Multiplier();
           static Comp4 GetComp12();

           Int32 GetNumber();
           Int32 GetNumber2();
       }
   }
 */

namespace Component
{
    // Original user code is unmodified.
    // Demonstrates component implementing interface, overloaded constructor and static functions
    public interface ITest4
    {
        int GetTest();
    }

    public class Comp4 : ITest4
    {
        public Comp4()
        {
            _num = 8;
        }

        public Comp4(int num)
        {
            _num = num;
        }

        public static int GetNum2Multiplier()
        {
            return 2;
        }

        public static Comp4 GetComp12()
        {
            return new Comp4(12);
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

// The below is the hand rolled projection for the above user code.

#pragma warning disable 0169 // warning CS0169: The field '...' is never used
#pragma warning disable 0649 // warning CS0169: Field '...' is never assigned to

namespace Component.Impl
{
    [global::WinRT.WindowsRuntimeType]
    [Guid("0B7AC6A9-A869-55E6-9828-AAA82370766F")]
    [global::Windows.Foundation.Metadata.ExclusiveTo(typeof(global::Component.Impl.Comp4))]
    [global::Windows.Foundation.Metadata.Version(1u)]
    internal interface IComp4
    {
        int GetNumber();
        int GetNumber2();
    }
    [global::WinRT.WindowsRuntimeType]
    [Guid("01657682-5E84-59E4-97D4-7E3A704EB078")]
    [global::Windows.Foundation.Metadata.ExclusiveTo(typeof(global::Component.Impl.Comp4))]
    [global::Windows.Foundation.Metadata.Version(1u)]
    internal interface IComp4Factory
    {
        Comp4 CreateInstance(int num);
    }
    [global::WinRT.WindowsRuntimeType]
    [Guid("CF54A495-6641-5C60-94E7-438846BFB877")]
    [global::Windows.Foundation.Metadata.ExclusiveTo(typeof(global::Component.Impl.Comp4))]
    [global::Windows.Foundation.Metadata.Version(1u)]
    internal interface IComp4Statics
    {
        int GetNum2Multiplier();
        Comp4 GetComp12();
    }

    [global::WinRT.WindowsRuntimeType]
    [Guid("D21205D2-44FF-5128-A1BF-BD20A0F42C1A")]
    [global::Windows.Foundation.Metadata.Version(1u)]
    internal interface ITest4
    {
        int GetTest();
    }

    public class Comp4 : IComp4, ITest4
    {
        public Comp4()
        {
            _comp = new global::Component.Comp4();
        }

        public Comp4(Int32 num)
        {
            _comp = new global::Component.Comp4(num);
        }

        public Comp4(global::Component.Comp4 comp)
        {
            _comp = comp;
        }

        public static Comp4 FromAbi(IntPtr thisPtr)
        {
            if (thisPtr == IntPtr.Zero) return null;
            var obj = MarshalInspectable.FromAbi(thisPtr);
            return obj is Comp4 ? (Comp4)obj : null;
        }

        public static Int32 GetNum2Multiplier()
        {
            return global::Component.Comp4.GetNum2Multiplier();
        }

        public static Comp4 GetComp12()
        {
            return new Comp4(global::Component.Comp4.GetComp12());
        }

        public Int32 GetNumber()
        {
            return _comp.GetNumber();
        }

        public Int32 GetNumber2()
        {
            return _comp.GetNumber2();
        }

        public Int32 GetTest()
        {
            return _comp.GetTest();
        }

        private readonly global::Component.Comp4 _comp;
    }
}

namespace ABI.Component.Impl
{
    // Generated code from CsWinRT

    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public struct Comp4
    {
        public static IObjectReference CreateMarshaler(global::Component.Impl.Comp4 obj) => obj is null ? null : MarshalInspectable.CreateMarshaler(obj).As<IComp4.Vftbl>();
        public static IntPtr GetAbi(IObjectReference value) => value is null ? IntPtr.Zero : MarshalInterfaceHelper<object>.GetAbi(value);
        public static global::Component.Impl.Comp4 FromAbi(IntPtr thisPtr) => global::Component.Impl.Comp4.FromAbi(thisPtr);
        public static IntPtr FromManaged(global::Component.Impl.Comp4 obj) => obj is null ? IntPtr.Zero : CreateMarshaler(obj).GetRef();
        public static unsafe MarshalInterfaceHelper<global::Component.Impl.Comp4>.MarshalerArray CreateMarshalerArray(global::Component.Impl.Comp4[] array) => MarshalInterfaceHelper<global::Component.Impl.Comp4>.CreateMarshalerArray(array, (o) => CreateMarshaler(o));
        public static (int length, IntPtr data) GetAbiArray(object box) => MarshalInterfaceHelper<global::Component.Impl.Comp4>.GetAbiArray(box);
        public static unsafe global::Component.Impl.Comp4[] FromAbiArray(object box) => MarshalInterfaceHelper<global::Component.Impl.Comp4>.FromAbiArray(box, FromAbi);
        public static (int length, IntPtr data) FromManagedArray(global::Component.Impl.Comp4[] array) => MarshalInterfaceHelper<global::Component.Impl.Comp4>.FromManagedArray(array, (o) => FromManaged(o));
        public static void DisposeMarshaler(IObjectReference value) => MarshalInspectable.DisposeMarshaler(value);
        public static void DisposeMarshalerArray(MarshalInterfaceHelper<global::Component.Impl.Comp4>.MarshalerArray array) => MarshalInterfaceHelper<global::Component.Impl.Comp4>.DisposeMarshalerArray(array);
        public static void DisposeAbi(IntPtr abi) => MarshalInspectable.DisposeAbi(abi);
        public static unsafe void DisposeAbiArray(object box) => MarshalInspectable.DisposeAbiArray(box);
    }

    [global::WinRT.ObjectReferenceWrapper(nameof(_obj))]
    [Guid("0B7AC6A9-A869-55E6-9828-AAA82370766F")]
    public class IComp4 : global::Component.Impl.IComp4
    {
        [Guid("0B7AC6A9-A869-55E6-9828-AAA82370766F")]
        public struct Vftbl
        {
            internal IInspectable.Vftbl IInspectableVftbl;
            public IComp4_Delegates.GetNumber_0 GetNumber_0;
            public IComp4_Delegates.GetNumber2_1 GetNumber2_1;

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
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.Impl.Comp4>(thisPtr).GetNumber();
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
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.Impl.Comp4>(thisPtr).GetNumber2();
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

        public static implicit operator IComp4(IObjectReference obj) => (obj != null) ? new IComp4(obj) : null;
        protected readonly ObjectReference<Vftbl> _obj;
        public IObjectReference ObjRef { get => _obj; }
        public IntPtr ThisPtr => _obj.ThisPtr;
        public ObjectReference<I> AsInterface<I>() => _obj.As<I>();
        public A As<A>() => _obj.AsType<A>();
        public IComp4(IObjectReference obj) : this(obj.As<Vftbl>()) { }
        internal IComp4(ObjectReference<Vftbl> obj)
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
    public static class IComp4_Delegates
    {
        public unsafe delegate int GetNumber_0(IntPtr thisPtr, out int result);
        public unsafe delegate int GetNumber2_1(IntPtr thisPtr, out int result);
    }

    [global::WinRT.ObjectReferenceWrapper(nameof(_obj))]
    [Guid("01657682-5E84-59E4-97D4-7E3A704EB078")]
    public class IComp4Factory : global::Component.Impl.IComp4Factory
    {
        [Guid("01657682-5E84-59E4-97D4-7E3A704EB078")]
        public struct Vftbl
        {
            internal IInspectable.Vftbl IInspectableVftbl;
            public IComp4Factory_Delegates.CreateInstance_0 CreateInstance_0;

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
                global::Component.Impl.Comp4 __value = default;

                value = default;

                try
                {
                    __value = global::WinRT.ComWrappersSupport.FindObject<global::Component.Impl.IComp4Factory>(thisPtr).CreateInstance(num);
                    value = global::ABI.Component.Impl.Comp4.FromManaged(__value);

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

        public static implicit operator IComp4Factory(IObjectReference obj) => (obj != null) ? new IComp4Factory(obj) : null;
        protected readonly ObjectReference<Vftbl> _obj;
        public IObjectReference ObjRef { get => _obj; }
        public IntPtr ThisPtr => _obj.ThisPtr;
        public ObjectReference<I> AsInterface<I>() => _obj.As<I>();
        public A As<A>() => _obj.AsType<A>();
        public IComp4Factory(IObjectReference obj) : this(obj.As<Vftbl>()) { }
        internal IComp4Factory(ObjectReference<Vftbl> obj)
        {
            _obj = obj;
        }

        public unsafe global::Component.Impl.Comp4 CreateInstance(int num)
        {
            IntPtr __retval = default;
            try
            {
                global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.CreateInstance_0(ThisPtr, num, out __retval));
                return global::ABI.Component.Impl.Comp4.FromAbi(__retval);
            }
            finally
            {
                global::ABI.Component.Impl.Comp4.DisposeAbi(__retval);
            }
        }
    }
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public static class IComp4Factory_Delegates
    {
        public unsafe delegate int CreateInstance_0(IntPtr thisPtr, int num, out IntPtr value);
    }

    [global::WinRT.ObjectReferenceWrapper(nameof(_obj))]
    [Guid("CF54A495-6641-5C60-94E7-438846BFB877")]
    public class IComp4Statics : global::Component.Impl.IComp4Statics
    {
        [Guid("CF54A495-6641-5C60-94E7-438846BFB877")]
        public struct Vftbl
        {
            internal IInspectable.Vftbl IInspectableVftbl;
            public IComp4Statics_Delegates.GetNum2Multiplier_0 GetNum2Multiplier_0;
            public IComp4Statics_Delegates.GetComp12_1 GetComp12_1;

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
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.Impl.IComp4Statics>(thisPtr).GetNum2Multiplier();
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
                global::Component.Impl.Comp4 __result = default;

                result = default;

                try
                {
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.Impl.IComp4Statics>(thisPtr).GetComp12();
                    result = global::ABI.Component.Impl.Comp4.FromManaged(__result);

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

        public static implicit operator IComp4Statics(IObjectReference obj) => (obj != null) ? new IComp4Statics(obj) : null;
        protected readonly ObjectReference<Vftbl> _obj;
        public IObjectReference ObjRef { get => _obj; }
        public IntPtr ThisPtr => _obj.ThisPtr;
        public ObjectReference<I> AsInterface<I>() => _obj.As<I>();
        public A As<A>() => _obj.AsType<A>();
        public IComp4Statics(IObjectReference obj) : this(obj.As<Vftbl>()) { }
        internal IComp4Statics(ObjectReference<Vftbl> obj)
        {
            _obj = obj;
        }

        public unsafe int GetNum2Multiplier()
        {
            int __retval = default;
            global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.GetNum2Multiplier_0(ThisPtr, out __retval));
            return __retval;
        }

        public unsafe global::Component.Impl.Comp4 GetComp12()
        {
            IntPtr __retval = default;
            try
            {
                global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.GetComp12_1(ThisPtr, out __retval));
                return global::ABI.Component.Impl.Comp4.FromAbi(__retval);
            }
            finally
            {
                global::ABI.Component.Impl.Comp4.DisposeAbi(__retval);
            }
        }
    }
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public static class IComp4Statics_Delegates
    {
        public unsafe delegate int GetNum2Multiplier_0(IntPtr thisPtr, out int result);
        public unsafe delegate int GetComp12_1(IntPtr thisPtr, out IntPtr result);
    }

    
    [global::WinRT.ObjectReferenceWrapper(nameof(_obj))]
    [Guid("D21205D2-44FF-5128-A1BF-BD20A0F42C1A")]
    public class ITest4 : global::Component.Impl.ITest4
    {
        [Guid("D21205D2-44FF-5128-A1BF-BD20A0F42C1A")]
        public struct Vftbl
        {
            internal IInspectable.Vftbl IInspectableVftbl;
            public ITest4_Delegates.GetTest_0 GetTest_0;

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
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.Impl.ITest4>(thisPtr).GetTest();
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

        public static implicit operator ITest4(IObjectReference obj) => (obj != null) ? new ITest4(obj) : null;
        protected readonly ObjectReference<Vftbl> _obj;
        public IObjectReference ObjRef { get => _obj; }
        public IntPtr ThisPtr => _obj.ThisPtr;
        public ObjectReference<I> AsInterface<I>() => _obj.As<I>();
        public A As<A>() => _obj.AsType<A>();
        public ITest4(IObjectReference obj) : this(obj.As<Vftbl>()) { }
        internal ITest4(ObjectReference<Vftbl> obj)
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
    public static class ITest4_Delegates
    {
        public unsafe delegate int GetTest_0(IntPtr thisPtr, out int result);
    }
   

    // Will be generated for each component that is activatable and will also implement the statics and factory interfaces.
    public class Comp4ServerActivationFactory : ProductionActivationFactory<global::Component.Impl.Comp4>, global::Component.Impl.IComp4Factory, global::Component.Impl.IComp4Statics
    {
        // Static function, either consumed through another generated static function
        // which handles all classes in this dll or via winrthost directly.
        public static IntPtr Make()
        {
            using var marshaler = MarshalInspectable.CreateMarshaler(_factory).As<IActivationFactory.Vftbl>();
            return marshaler.GetRef();
        }

        static readonly Comp4ServerActivationFactory _factory = new Comp4ServerActivationFactory();
        public static ObjectReference<I> ActivateInstance<I>()
        {
            IntPtr instance = _factory.ActivateInstance();
            return ObjectReference<IInspectable.Vftbl>.Attach(ref instance).As<I>();
        }

        // Note we no longer need to convert to the projected type as the server is the proejcted
        // type for C# callers.
        public global::Component.Impl.Comp4 CreateInstance(int num)
        {
            return new global::Component.Impl.Comp4(num);
        }

        public int GetNum2Multiplier()
        {
            return global::Component.Impl.Comp4.GetNum2Multiplier();
        }

        // Note we no longer need to convert to the projected type as the server is the proejcted
        // type for C# callers.
        public global::Component.Impl.Comp4 GetComp12()
        {
            return global::Component.Impl.Comp4.GetComp12();
        }
    }
}