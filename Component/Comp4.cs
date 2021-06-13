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
using Windows.Foundation;
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

       runtimeclass Comp4 : ITest4, Windows.Foundation.IWwwFormUrlDecoderEntry
       {
           Comp4();
           Comp4(Int32 num);

           static Int32 GetNum2Multiplier();
           static Comp4 GetComp12();

           Int32 GetNumber();
           Int32 GetNumber2();

           IVector<Comp5> GetList();
       }

       runtimeclass Comp5
       {
           Comp5();

           Int32 GetCustomTest(ITest4 test);
           Int32 SetCustomNumber(Comp4 comp);
           Windows.Foundation.Point GetPoint();
       }
   }
 */

namespace Component
{
    // Original user code is unmodified.
    // Demonstrates component implementing interface, overloaded constructor, static functions, and generics.
    public interface ITest4
    {
        int GetTest();
    }

    // Note implementing interface from projected Windows SDK.
    public class Comp4 : ITest4, Windows.Foundation.IWwwFormUrlDecoderEntry
    {
        public Comp4()
        {
            _num = 8;
            _list = new List<Comp5>();
        }

        public Comp4(int num)
        {
            _num = num;
            _list = new List<Comp5>();
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

        // Use of generics and list
        public IList<Comp5> GetList()
        {
            Comp5 comp = new Comp5();
            comp.SetCustomNumber(this);
            _list.Add(comp);
            return _list;
        }

        public string Name => _num.ToString();

        public string Value => (_num * 2).ToString();

        private int _num;
        private List<Comp5> _list;
    }

    public class Comp5
    {
        public Comp5()
        {
            num = 1;
        }

        public int GetCustomTest(ITest4 test)
        {
            return test.GetTest();
        }

        public int SetCustomNumber(Comp4 comp)
        {
            num = comp.GetNumber();
            return num;
        }

        public Point GetPoint()
        {
            return new Point(num, num);
        }

        private int num;
    }
}

// The below is the hand rolled projection for the above user code.

#pragma warning disable 0169 // warning CS0169: The field '...' is never used
#pragma warning disable 0649 // warning CS0169: Field '...' is never assigned to

namespace Component.Impl
{
    // Note we don't create anything for IWwwFormUrlDecoderEntry.

    [global::WinRT.WindowsRuntimeType]
    [Guid("ACEE4AFC-C98E-571F-AE1E-1479294A162C")]
    [global::Windows.Foundation.Metadata.ExclusiveTo(typeof(global::Component.Impl.Comp4))]
    [global::Windows.Foundation.Metadata.Version(1u)]
    internal interface IComp4
    {
        int GetNumber();
        int GetNumber2();
        // Note we do not remap types to wrappers (i.e.Comp5), it is left to the CCW support.
        IList<global::Component.Comp5> GetList();
    }
    [global::WinRT.WindowsRuntimeType]
    [Guid("D72643F7-A950-5AE9-BFDF-36C620A92481")]
    [global::Windows.Foundation.Metadata.ExclusiveTo(typeof(global::Component.Impl.Comp4))]
    [global::Windows.Foundation.Metadata.Version(1u)]
    internal interface IComp4Factory
    {
        global::Component.Comp4 CreateInstance(int num);
    }
    [global::WinRT.WindowsRuntimeType]
    [Guid("B0D0BBEA-4F52-58B1-A8CE-2B9192F29F1F")]
    [global::Windows.Foundation.Metadata.ExclusiveTo(typeof(global::Component.Impl.Comp4))]
    [global::Windows.Foundation.Metadata.Version(1u)]
    internal interface IComp4Statics
    {
        int GetNum2Multiplier();
        global::Component.Comp4 GetComp12();
    }

    [global::WinRT.WindowsRuntimeType]
    [Guid("D21205D2-44FF-5128-A1BF-BD20A0F42C1A")]
    [global::Windows.Foundation.Metadata.Version(1u)]
    public interface ITest4
    {
        int GetTest();
    }

    // I currently make use of ProjectedRuntimeClass for the default interface mapping.
    // But I imagine that being changed to a different attribute or naming convention as I don't
    // want the redundant _default property.
    [global::WinRT.WindowsRuntimeType]
    [global::WinRT.ProjectedRuntimeClass(nameof(_default))]
    [Windows.Foundation.Metadata.Activatable(1u)]
    [Windows.Foundation.Metadata.MarshalingBehavior(global::Windows.Foundation.Metadata.MarshalingType.Agile)]
    [Windows.Foundation.Metadata.Threading(global::Windows.Foundation.Metadata.ThreadingModel.Both)]
    [Windows.Foundation.Metadata.Version(1u)]
    public class Comp4 : IComp4, ITest4, Windows.Foundation.IWwwFormUrlDecoderEntry
    {
        // temporary - see earlier comment
        private global::ABI.Component.Impl.IComp4 _default => null;

        public Comp4(global::Component.Comp4 comp)
        {
            _comp = comp;
        }

        public static implicit operator global::Component.Comp4(Comp4 comp)
        {
            return comp._comp;
        }

        public static implicit operator Comp4(global::Component.Comp4 comp)
        {
            return new Comp4(comp);
        }

        // Note the return type is for the user's type and not the wrapper's type
        // even though ThisPtr was for wrapper's type.
        public static global::Component.Comp4 FromAbi(IntPtr thisPtr)
        {
            if (thisPtr == IntPtr.Zero) return null;
            var obj = MarshalInspectable.FromAbi(thisPtr);
            return obj is Comp4 ? (Comp4)obj : null;
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

        public IList<global::Component.Comp5> GetList()
        {
            return _comp.GetList();
        }

        public string Name => _comp.Name;

        public string Value => _comp.Value;

        private readonly global::Component.Comp4 _comp;
    }

    [global::WinRT.WindowsRuntimeType]
    [Guid("B2390075-4C21-5364-BEFF-3193FA650F44")]
    [global::Windows.Foundation.Metadata.ExclusiveTo(typeof(global::Component.Impl.Comp5))]
    [global::Windows.Foundation.Metadata.Version(1u)]
    public interface IComp5
    {
        int GetCustomTest(global::Component.ITest4 test);
        int SetCustomNumber(global::Component.Comp4 comp);
        Point GetPoint();
    }

    [global::WinRT.WindowsRuntimeType]
    [global::WinRT.ProjectedRuntimeClass(nameof(_default))]
    [Windows.Foundation.Metadata.Activatable(1u)]
    [Windows.Foundation.Metadata.MarshalingBehavior(global::Windows.Foundation.Metadata.MarshalingType.Agile)]
    [Windows.Foundation.Metadata.Threading(global::Windows.Foundation.Metadata.ThreadingModel.Both)]
    [Windows.Foundation.Metadata.Version(1u)]
    public class Comp5 : IComp5
    {
        // temporary
        private global::ABI.Component.Impl.IComp5 _default => null;

        public Comp5(global::Component.Comp5 comp)
        {
            _comp = comp;
        }

        public static implicit operator global::Component.Comp5(Comp5 comp)
        {
            return comp._comp;
        }

        public static implicit operator Comp5(global::Component.Comp5 comp)
        {
            return new Comp5(comp);
        }

        public static global::Component.Comp5 FromAbi(IntPtr thisPtr)
        {
            if (thisPtr == IntPtr.Zero) return null;
            var obj = MarshalInspectable.FromAbi(thisPtr);
            return obj is Comp5 ? (Comp5)obj : null;
        }

        public int GetCustomTest(global::Component.ITest4 test)
        {
            return _comp.GetCustomTest(test);
        }

        public int SetCustomNumber(global::Component.Comp4 comp)
        {
            return _comp.SetCustomNumber(comp);
        }

        public Point GetPoint()
        {
            return _comp.GetPoint();
        }

        private readonly global::Component.Comp5 _comp;
    }
}

namespace ABI.Component.Impl
{
    // Generated code from CsWinRT with namespace modifications

    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public struct Comp4
    {
        public static IObjectReference CreateMarshaler(global::Component.Comp4 obj) => obj is null ? null : MarshalInspectable.CreateMarshaler(obj, false).As<IComp4.Vftbl>();
        public static IntPtr GetAbi(IObjectReference value) => value is null ? IntPtr.Zero : MarshalInterfaceHelper<object>.GetAbi(value);
        public static global::Component.Comp4 FromAbi(IntPtr thisPtr) => global::Component.Impl.Comp4.FromAbi(thisPtr);
        public static IntPtr FromManaged(global::Component.Comp4 obj) => obj is null ? IntPtr.Zero : CreateMarshaler(obj).GetRef();
        public static unsafe MarshalInterfaceHelper<global::Component.Comp4>.MarshalerArray CreateMarshalerArray(global::Component.Comp4[] array) => MarshalInterfaceHelper<global::Component.Comp4>.CreateMarshalerArray(array, (o) => CreateMarshaler(o));
        public static (int length, IntPtr data) GetAbiArray(object box) => MarshalInterfaceHelper<global::Component.Comp4>.GetAbiArray(box);
        public static unsafe global::Component.Comp4[] FromAbiArray(object box) => MarshalInterfaceHelper<global::Component.Comp4>.FromAbiArray(box, FromAbi);
        public static (int length, IntPtr data) FromManagedArray(global::Component.Comp4[] array) => MarshalInterfaceHelper<global::Component.Comp4>.FromManagedArray(array, (o) => FromManaged(o));
        public static void DisposeMarshaler(IObjectReference value) => MarshalInspectable.DisposeMarshaler(value);
        public static void DisposeMarshalerArray(MarshalInterfaceHelper<global::Component.Comp4>.MarshalerArray array) => MarshalInterfaceHelper<global::Component.Comp4>.DisposeMarshalerArray(array);
        public static void DisposeAbi(IntPtr abi) => MarshalInspectable.DisposeAbi(abi);
        public static unsafe void DisposeAbiArray(object box) => MarshalInspectable.DisposeAbiArray(box);
    }

    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public struct Comp5
    {
        public static IObjectReference CreateMarshaler(global::Component.Comp5 obj) => obj is null ? null : MarshalInspectable.CreateMarshaler(obj, false).As<IComp5.Vftbl>();
        public static IntPtr GetAbi(IObjectReference value) => value is null ? IntPtr.Zero : MarshalInterfaceHelper<object>.GetAbi(value);
        public static global::Component.Comp5 FromAbi(IntPtr thisPtr) => global::Component.Impl.Comp5.FromAbi(thisPtr);
        public static IntPtr FromManaged(global::Component.Comp5 obj) => obj is null ? IntPtr.Zero : CreateMarshaler(obj).GetRef();
        public static unsafe MarshalInterfaceHelper<global::Component.Comp5>.MarshalerArray CreateMarshalerArray(global::Component.Comp5[] array) => MarshalInterfaceHelper<global::Component.Comp5>.CreateMarshalerArray(array, (o) => CreateMarshaler(o));
        public static (int length, IntPtr data) GetAbiArray(object box) => MarshalInterfaceHelper<global::Component.Comp5>.GetAbiArray(box);
        public static unsafe global::Component.Comp5[] FromAbiArray(object box) => MarshalInterfaceHelper<global::Component.Comp5>.FromAbiArray(box, FromAbi);
        public static (int length, IntPtr data) FromManagedArray(global::Component.Comp5[] array) => MarshalInterfaceHelper<global::Component.Comp5>.FromManagedArray(array, (o) => FromManaged(o));
        public static void DisposeMarshaler(IObjectReference value) => MarshalInspectable.DisposeMarshaler(value);
        public static void DisposeMarshalerArray(MarshalInterfaceHelper<global::Component.Comp5>.MarshalerArray array) => MarshalInterfaceHelper<global::Component.Comp5>.DisposeMarshalerArray(array);
        public static void DisposeAbi(IntPtr abi) => MarshalInspectable.DisposeAbi(abi);
        public static unsafe void DisposeAbiArray(object box) => MarshalInspectable.DisposeAbiArray(box);
    }

    [global::WinRT.ObjectReferenceWrapper(nameof(_obj))]
    [Guid("ACEE4AFC-C98E-571F-AE1E-1479294A162C")]
    public class IComp4 : global::Component.Impl.IComp4
    {
        [Guid("ACEE4AFC-C98E-571F-AE1E-1479294A162C")]
        public struct Vftbl
        {
            internal IInspectable.Vftbl IInspectableVftbl;
            public IComp4_Delegates.GetNumber_0 GetNumber_0;
            public IComp4_Delegates.GetNumber2_1 GetNumber2_1;
            public IComp4_Delegates.GetList_2 GetList_2;

            private static readonly Vftbl AbiToProjectionVftable;
            public static readonly IntPtr AbiToProjectionVftablePtr;
            static unsafe Vftbl()
            {
                AbiToProjectionVftable = new Vftbl
                {
                    IInspectableVftbl = global::WinRT.IInspectable.Vftbl.AbiToProjectionVftable,
                    GetNumber_0 = Do_Abi_GetNumber_0,
                    GetNumber2_1 = Do_Abi_GetNumber2_1,
                    GetList_2 = Do_Abi_GetList_2
                };
                var nativeVftbl = (IntPtr*)ComWrappersSupport.AllocateVtableMemory(typeof(Vftbl), Marshal.SizeOf<global::WinRT.IInspectable.Vftbl>() + sizeof(IntPtr) * 3);
                Marshal.StructureToPtr(AbiToProjectionVftable, (IntPtr)nativeVftbl, false);
                AbiToProjectionVftablePtr = (IntPtr)nativeVftbl;
            }

            private static unsafe int Do_Abi_GetNumber_0(IntPtr thisPtr, out int result)
            {
                int __result = default;

                result = default;

                try
                {
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.Impl.IComp4>(thisPtr).GetNumber();
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
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.Impl.IComp4>(thisPtr).GetNumber2();
                    result = __result;

                }
                catch (Exception __exception__)
                {
                    global::WinRT.ExceptionHelpers.SetErrorInfo(__exception__);
                    return global::WinRT.ExceptionHelpers.GetHRForException(__exception__);
                }
                return 0;
            }
            private static unsafe int Do_Abi_GetList_2(IntPtr thisPtr, out IntPtr result)
            {
                global::System.Collections.Generic.IList<global::Component.Comp5> __result = default;

                result = default;

                try
                {
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.Impl.IComp4>(thisPtr).GetList();
                    result = global::ABI.System.Collections.Generic.IList<global::Component.Comp5>.FromManaged(__result);

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

        public unsafe global::System.Collections.Generic.IList<global::Component.Comp5> GetList()
        {
            IntPtr __retval = default;
            try
            {
                global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.GetList_2(ThisPtr, out __retval));
                return global::ABI.System.Collections.Generic.IList<global::Component.Comp5>.FromAbi(__retval);
            }
            finally
            {
                global::ABI.System.Collections.Generic.IList<global::Component.Comp5>.DisposeAbi(__retval);
            }
        }
    }
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public static class IComp4_Delegates
    {
        public unsafe delegate int GetNumber_0(IntPtr thisPtr, out int result);
        public unsafe delegate int GetNumber2_1(IntPtr thisPtr, out int result);
        public unsafe delegate int GetList_2(IntPtr thisPtr, out IntPtr result);
    }

    [global::WinRT.ObjectReferenceWrapper(nameof(_obj))]
    [Guid("D72643F7-A950-5AE9-BFDF-36C620A92481")]
    public class IComp4Factory : global::Component.Impl.IComp4Factory
    {
        [Guid("D72643F7-A950-5AE9-BFDF-36C620A92481")]
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
                global::Component.Comp4 __value = default;

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

        public unsafe global::Component.Comp4 CreateInstance(int num)
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
    [Guid("B0D0BBEA-4F52-58B1-A8CE-2B9192F29F1F")]
    public class IComp4Statics : global::Component.Impl.IComp4Statics
    {
        [Guid("B0D0BBEA-4F52-58B1-A8CE-2B9192F29F1F")]
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
                global::Component.Comp4 __result = default;

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

        public unsafe global::Component.Comp4 GetComp12()
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
    [Guid("B2390075-4C21-5364-BEFF-3193FA650F44")]
    public class IComp5 : global::Component.Impl.IComp5
    {
        [Guid("B2390075-4C21-5364-BEFF-3193FA650F44")]
        public struct Vftbl
        {
            internal IInspectable.Vftbl IInspectableVftbl;
            public IComp5_Delegates.GetCustomTest_0 GetCustomTest_0;
            public IComp5_Delegates.SetCustomNumber_1 SetCustomNumber_1;
            public IComp5_Delegates.GetPoint_2 GetPoint_2;

            private static readonly Vftbl AbiToProjectionVftable;
            public static readonly IntPtr AbiToProjectionVftablePtr;
            static unsafe Vftbl()
            {
                AbiToProjectionVftable = new Vftbl
                {
                    IInspectableVftbl = global::WinRT.IInspectable.Vftbl.AbiToProjectionVftable,
                    GetCustomTest_0 = Do_Abi_GetCustomTest_0,
                    SetCustomNumber_1 = Do_Abi_SetCustomNumber_1,
                    GetPoint_2 = Do_Abi_GetPoint_2
                };
                var nativeVftbl = (IntPtr*)ComWrappersSupport.AllocateVtableMemory(typeof(Vftbl), Marshal.SizeOf<global::WinRT.IInspectable.Vftbl>() + sizeof(IntPtr) * 3);
                Marshal.StructureToPtr(AbiToProjectionVftable, (IntPtr)nativeVftbl, false);
                AbiToProjectionVftablePtr = (IntPtr)nativeVftbl;
            }

            private static unsafe int Do_Abi_GetCustomTest_0(IntPtr thisPtr, IntPtr test, out int result)
            {
                int __result = default;

                result = default;

                try
                {
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.Impl.IComp5>(thisPtr).GetCustomTest(MarshalInterface<global::Component.ITest4>.FromAbi(test));
                    result = __result;

                }
                catch (Exception __exception__)
                {
                    global::WinRT.ExceptionHelpers.SetErrorInfo(__exception__);
                    return global::WinRT.ExceptionHelpers.GetHRForException(__exception__);
                }
                return 0;
            }
            private static unsafe int Do_Abi_SetCustomNumber_1(IntPtr thisPtr, IntPtr comp, out int result)
            {
                int __result = default;

                result = default;

                try
                {
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.Impl.IComp5>(thisPtr).SetCustomNumber(global::ABI.Component.Impl.Comp4.FromAbi(comp));
                    result = __result;

                }
                catch (Exception __exception__)
                {
                    global::WinRT.ExceptionHelpers.SetErrorInfo(__exception__);
                    return global::WinRT.ExceptionHelpers.GetHRForException(__exception__);
                }
                return 0;
            }
            private static unsafe int Do_Abi_GetPoint_2(IntPtr thisPtr, out global::Windows.Foundation.Point result)
            {
                global::Windows.Foundation.Point __result = default;

                result = default;

                try
                {
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.Impl.IComp5>(thisPtr).GetPoint();
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

        public static implicit operator IComp5(IObjectReference obj) => (obj != null) ? new IComp5(obj) : null;
        protected readonly ObjectReference<Vftbl> _obj;
        public IObjectReference ObjRef { get => _obj; }
        public IntPtr ThisPtr => _obj.ThisPtr;
        public ObjectReference<I> AsInterface<I>() => _obj.As<I>();
        public A As<A>() => _obj.AsType<A>();
        public IComp5(IObjectReference obj) : this(obj.As<Vftbl>()) { }
        internal IComp5(ObjectReference<Vftbl> obj)
        {
            _obj = obj;
        }

        public unsafe int GetCustomTest(global::Component.ITest4 test)
        {
            IObjectReference __test = default;
            int __retval = default;
            try
            {
                __test = MarshalInterface<global::Component.ITest4>.CreateMarshaler(test);
                global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.GetCustomTest_0(ThisPtr, MarshalInterface<global::Component.ITest4>.GetAbi(__test), out __retval));
                return __retval;
            }
            finally
            {
                MarshalInterface<global::Component.ITest4>.DisposeMarshaler(__test);
            }
        }

        public unsafe int SetCustomNumber(global::Component.Comp4 comp)
        {
            IObjectReference __comp = default;
            int __retval = default;
            try
            {
                __comp = global::ABI.Component.Impl.Comp4.CreateMarshaler(comp);
                global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.SetCustomNumber_1(ThisPtr, global::ABI.Component.Impl.Comp4.GetAbi(__comp), out __retval));
                return __retval;
            }
            finally
            {
                global::ABI.Component.Impl.Comp4.DisposeMarshaler(__comp);
            }
        }

        public unsafe global::Windows.Foundation.Point GetPoint()
        {
            global::Windows.Foundation.Point __retval = default;
            global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.GetPoint_2(ThisPtr, out __retval));
            return __retval;
        }
    }
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public static class IComp5_Delegates
    {
        public unsafe delegate int GetCustomTest_0(IntPtr thisPtr, IntPtr test, out int result);
        public unsafe delegate int SetCustomNumber_1(IntPtr thisPtr, IntPtr comp, out int result);
        public unsafe delegate int GetPoint_2(IntPtr thisPtr, out global::Windows.Foundation.Point result);
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
    public class Comp4ServerActivationFactory : ProductionActivationFactory<global::Component.Comp4>, global::Component.Impl.IComp4Factory, global::Component.Impl.IComp4Statics
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

        public global::Component.Comp4 CreateInstance(int num)
        {
            return new global::Component.Comp4(num);
        }

        public int GetNum2Multiplier()
        {
            return global::Component.Comp4.GetNum2Multiplier();
        }

        public global::Component.Comp4 GetComp12()
        {
            return global::Component.Comp4.GetComp12();
        }
    }

    public class Comp5ServerActivationFactory : ProductionActivationFactory<global::Component.Comp5>
    {
        // Static function, either consumed through another generated static function
        // which handles all classes in this dll or via winrthost directly.
        public static IntPtr Make()
        {
            using var marshaler = MarshalInspectable.CreateMarshaler(_factory).As<IActivationFactory.Vftbl>();
            return marshaler.GetRef();
        }

        static readonly Comp5ServerActivationFactory _factory = new Comp5ServerActivationFactory();
        public static ObjectReference<I> ActivateInstance<I>()
        {
            IntPtr instance = _factory.ActivateInstance();
            return ObjectReference<IInspectable.Vftbl>.Attach(ref instance).As<I>();
        }
    }

}