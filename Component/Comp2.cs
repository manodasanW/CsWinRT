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
 * Original code for the below hand rolled projection to demonstrate what the generated code and changes would look like and to validate it.
 * Original components implements interface, has overloaded constructor and static functions. 
 * 
  namespace Component
  {

   public interface ITest
   {
       int GetTest();
   }

   public class Comp2 : ITest
   {
       public Comp2()
       {
           _num = 5;
       }

       public Comp2(int num)
       {
           _num = num;
       }

       static Int32 GetNum2Multiplier()
       {
            return 2;
       }

       static Comp2 GetComp12()
       {
            return new Comp2(12);
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

       runtimeclass Comp2 : ITest
       {
           Comp2();
           Comp2(Int32 num);

           static Int32 GetNum2Multiplier();
           static Comp2 GetComp12();

           Int32 GetNumber();
           Int32 GetNumber2();
       }
   }
 */

namespace Component
{
    // Note the rename of the class and the addition of inheriting default interface.
     public class Comp2Server : global::Component.IComp2, global::Component.ITest
    {
        public Comp2Server()
        {
            _num = 8;
        }

        public Comp2Server(int num)
        {
            _num = num;
        }

        public static int GetNum2Multiplier()
        {
            return 2;
        }

        public static Comp2Server GetComp12()
        {
            return new Comp2Server(12);
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
    [global::WinRT.ProjectedRuntimeClass(nameof(_default))]
    [Windows.Foundation.Metadata.Activatable(1u)]
    [Windows.Foundation.Metadata.MarshalingBehavior(global::Windows.Foundation.Metadata.MarshalingType.Agile)]
    [Windows.Foundation.Metadata.Static(typeof(IComp2Statics), 1u)]
    [Windows.Foundation.Metadata.Threading(global::Windows.Foundation.Metadata.ThreadingModel.Both)]
    [Windows.Foundation.Metadata.Version(1u)]
    public sealed class Comp2 : ITest, global::System.Runtime.InteropServices.ICustomQueryInterface, IEquatable<Comp2>
    {
        public IntPtr ThisPtr => _default.ThisPtr;

        private IObjectReference _inner = null;
        private readonly Lazy<global::ABI.Component.IComp2> _defaultLazy;
        private readonly Dictionary<Type, object> _lazyInterfaces;

        private global::ABI.Component.IComp2 _default => _defaultLazy.Value;

        // Note change in ActivationFactory
        public Comp2() : this(new global::ABI.Component.IComp2(Comp2ServerActivationFactory.ActivateInstance<global::ABI.Component.IComp2.Vftbl>()))
        {
            ComWrappersSupport.RegisterObjectForInterface(this, ThisPtr);
        }

        internal class _IComp2Factory : ABI.Component.IComp2Factory
        {
            // Note change in ActivationFactory
            public _IComp2Factory() : base(ObjectReference<ABI.Component.IActivationFactory.Vftbl>.FromAbi(Comp2ServerActivationFactory.Make()).As<ABI.Component.IComp2Factory.Vftbl>()) { }
            private static _IComp2Factory _instance = new _IComp2Factory();
            internal static _IComp2Factory Instance => _instance;

            public unsafe new IntPtr CreateInstance(int num)
            {
                IntPtr __retval = default;
                global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.CreateInstance_0(ThisPtr, num, out __retval));
                return __retval;
            }

        }

        public Comp2(int num) : this(((Func<global::ABI.Component.IComp2>)(() => {
            IntPtr ptr = (_IComp2Factory.Instance.CreateInstance(num));
            try
            {
                return new global::ABI.Component.IComp2(ComWrappersSupport.GetObjectReferenceForInterface(ptr));
            }
            finally
            {
                MarshalInspectable.DisposeAbi(ptr);
            }
        }))())
        {
            ComWrappersSupport.RegisterObjectForInterface(this, ThisPtr);
        }

        internal class _IComp2Statics : ABI.Component.IComp2Statics
        {
            // Note change in ActivationFactory
            public _IComp2Statics() : base(ObjectReference<ABI.Component.IActivationFactory.Vftbl>.FromAbi(Comp2ServerActivationFactory.Make()).As<ABI.Component.IComp2Statics.Vftbl>()) { }
            private static _IComp2Statics _instance = new _IComp2Statics();
            internal static IComp2Statics Instance => _instance;
        }

        public static int GetNum2Multiplier() => _IComp2Statics.Instance.GetNum2Multiplier();

        public static Comp2 GetComp12() => _IComp2Statics.Instance.GetComp12();

        // I had to add handling of the server component (Comp2Server) here as FromAbi detects thisPtr as a reference
        // to a managed object and recovers the original object causing it to be not a instance of the wrapper Comp2 class.
        // We can probably handle this in CsWinRT through an attribute specified on the meatadata and naming convention.
        public static Comp2 FromAbi(IntPtr thisPtr)
        {
            if (thisPtr == IntPtr.Zero) return null;
            var obj = MarshalInspectable.FromAbi(thisPtr);
            if(obj is Comp2)
            {
                return (Comp2)obj;
            }
            else if(obj is Comp2Server)
            {
                return new Comp2(MarshalInspectable.CreateMarshaler(obj).As<global::ABI.Component.IComp2.Vftbl>());
            }
            else
            {
                return new Comp2((global::ABI.Component.IComp2)obj);
            }
        }

        internal Comp2(global::ABI.Component.IComp2 ifc)
        {
            _defaultLazy = new Lazy<global::ABI.Component.IComp2>(() => ifc);
            _lazyInterfaces = new Dictionary<Type, object>()
            {
                {typeof(ITest), new Lazy<global::ABI.Component.ITest>(() => new global::ABI.Component.ITest(GetReferenceForQI()))},
            };
        }

        public static bool operator ==(Comp2 x, Comp2 y) => (x?.ThisPtr ?? IntPtr.Zero) == (y?.ThisPtr ?? IntPtr.Zero);
        public static bool operator !=(Comp2 x, Comp2 y) => !(x == y);
        public bool Equals(Comp2 other) => this == other;
        public override bool Equals(object obj) => obj is Comp2 that && this == that;
        public override int GetHashCode() => ThisPtr.GetHashCode();

        private IObjectReference GetDefaultReference<T>() => _default.AsInterface<T>();
        private IObjectReference GetReferenceForQI() => _inner ?? _default.ObjRef;

        private struct InterfaceTag<I> { };

        private IComp2 AsInternal(InterfaceTag<IComp2> _) => _default;

        public int GetNumber() => _default.GetNumber();

        public int GetNumber2() => _default.GetNumber2();

        private ITest AsInternal(InterfaceTag<ITest> _) => ((Lazy<global::ABI.Component.ITest>)_lazyInterfaces[typeof(ITest)]).Value;

        public int GetTest() => AsInternal(new InterfaceTag<ITest>()).GetTest();

        int ITest.GetTest() => GetTest();
        private bool IsOverridableInterface(Guid iid) => false;

        global::System.Runtime.InteropServices.CustomQueryInterfaceResult global::System.Runtime.InteropServices.ICustomQueryInterface.GetInterface(ref Guid iid, out IntPtr ppv)
        {
            ppv = IntPtr.Zero;
            if (IsOverridableInterface(iid) || typeof(global::WinRT.IInspectable).GUID == iid)
            {
                return global::System.Runtime.InteropServices.CustomQueryInterfaceResult.NotHandled;
            }

            if (GetReferenceForQI().TryAs<IUnknownVftbl>(iid, out ObjectReference<IUnknownVftbl> objRef) >= 0)
            {
                using (objRef)
                {
                    ppv = objRef.GetRef();
                    return global::System.Runtime.InteropServices.CustomQueryInterfaceResult.Handled;
                }
            }

            return global::System.Runtime.InteropServices.CustomQueryInterfaceResult.NotHandled;
        }
    }

    [global::WinRT.WindowsRuntimeType]
    [Guid("0B7AC6A9-A869-55E6-9828-AAA82370766F")]
    [Windows.Foundation.Metadata.ExclusiveTo(typeof(Comp2))]
    [Windows.Foundation.Metadata.Version(1u)]
    internal interface IComp2
    {
        int GetNumber();
        int GetNumber2();
    }
    [global::WinRT.WindowsRuntimeType]
    [Guid("01657682-5E84-59E4-97D4-7E3A704EB078")]
    [Windows.Foundation.Metadata.ExclusiveTo(typeof(Comp2))]
    [Windows.Foundation.Metadata.Version(1u)]
    internal interface IComp2Factory
    {
        Comp2 CreateInstance(int num);
    }
    [global::WinRT.WindowsRuntimeType]
    [Guid("CF54A495-6641-5C60-94E7-438846BFB877")]
    [Windows.Foundation.Metadata.ExclusiveTo(typeof(Comp2))]
    [Windows.Foundation.Metadata.Version(1u)]
    internal interface IComp2Statics
    {
        int GetNum2Multiplier();
        Comp2 GetComp12();
    }

    // Note that this interface would be part of the original component's code,
    // but we generate a new one as we need attributes on it.
    [global::WinRT.WindowsRuntimeType]
    [Guid("D21205D2-44FF-5128-A1BF-BD20A0F42C1A")]
    [Windows.Foundation.Metadata.Version(1u)]
    public interface ITest
    {
        int GetTest();
    }
}

namespace ABI.Component
{
    // Generated code from CsWinRT

    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public struct Comp2
    {
        public static IObjectReference CreateMarshaler(global::Component.Comp2 obj) => obj is null ? null : MarshalInspectable.CreateMarshaler(obj).As<IComp2.Vftbl>();
        public static IntPtr GetAbi(IObjectReference value) => value is null ? IntPtr.Zero : MarshalInterfaceHelper<object>.GetAbi(value);
        public static global::Component.Comp2 FromAbi(IntPtr thisPtr) => global::Component.Comp2.FromAbi(thisPtr);
        public static IntPtr FromManaged(global::Component.Comp2 obj) => obj is null ? IntPtr.Zero : CreateMarshaler(obj).GetRef();
        public static unsafe MarshalInterfaceHelper<global::Component.Comp2>.MarshalerArray CreateMarshalerArray(global::Component.Comp2[] array) => MarshalInterfaceHelper<global::Component.Comp2>.CreateMarshalerArray(array, (o) => CreateMarshaler(o));
        public static (int length, IntPtr data) GetAbiArray(object box) => MarshalInterfaceHelper<global::Component.Comp2>.GetAbiArray(box);
        public static unsafe global::Component.Comp2[] FromAbiArray(object box) => MarshalInterfaceHelper<global::Component.Comp2>.FromAbiArray(box, FromAbi);
        public static (int length, IntPtr data) FromManagedArray(global::Component.Comp2[] array) => MarshalInterfaceHelper<global::Component.Comp2>.FromManagedArray(array, (o) => FromManaged(o));
        public static void DisposeMarshaler(IObjectReference value) => MarshalInspectable.DisposeMarshaler(value);
        public static void DisposeMarshalerArray(MarshalInterfaceHelper<global::Component.Comp2>.MarshalerArray array) => MarshalInterfaceHelper<global::Component.Comp2>.DisposeMarshalerArray(array);
        public static void DisposeAbi(IntPtr abi) => MarshalInspectable.DisposeAbi(abi);
        public static unsafe void DisposeAbiArray(object box) => MarshalInspectable.DisposeAbiArray(box);
    }

    [global::WinRT.ObjectReferenceWrapper(nameof(_obj))]
    [Guid("0B7AC6A9-A869-55E6-9828-AAA82370766F")]
    public class IComp2 : global::Component.IComp2
    {
        [Guid("0B7AC6A9-A869-55E6-9828-AAA82370766F")]
        public struct Vftbl
        {
            internal IInspectable.Vftbl IInspectableVftbl;
            public IComp2_Delegates.GetNumber_0 GetNumber_0;
            public IComp2_Delegates.GetNumber2_1 GetNumber2_1;

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
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.IComp2>(thisPtr).GetNumber();
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
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.IComp2>(thisPtr).GetNumber2();
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

        public static implicit operator IComp2(IObjectReference obj) => (obj != null) ? new IComp2(obj) : null;
        protected readonly ObjectReference<Vftbl> _obj;
        public IObjectReference ObjRef { get => _obj; }
        public IntPtr ThisPtr => _obj.ThisPtr;
        public ObjectReference<I> AsInterface<I>() => _obj.As<I>();
        public A As<A>() => _obj.AsType<A>();
        public IComp2(IObjectReference obj) : this(obj.As<Vftbl>()) { }
        internal IComp2(ObjectReference<Vftbl> obj)
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
    public static class IComp2_Delegates
    {
        public unsafe delegate int GetNumber_0(IntPtr thisPtr, out int result);
        public unsafe delegate int GetNumber2_1(IntPtr thisPtr, out int result);
    }

    [global::WinRT.ObjectReferenceWrapper(nameof(_obj))]
    [Guid("01657682-5E84-59E4-97D4-7E3A704EB078")]
    public class IComp2Factory : global::Component.IComp2Factory
    {
        [Guid("01657682-5E84-59E4-97D4-7E3A704EB078")]
        public struct Vftbl
        {
            internal IInspectable.Vftbl IInspectableVftbl;
            public IComp2Factory_Delegates.CreateInstance_0 CreateInstance_0;

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
                global::Component.Comp2 __value = default;

                value = default;

                try
                {
                    __value = global::WinRT.ComWrappersSupport.FindObject<global::Component.IComp2Factory>(thisPtr).CreateInstance(num);
                    value = global::ABI.Component.Comp2.FromManaged(__value);

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

        public static implicit operator IComp2Factory(IObjectReference obj) => (obj != null) ? new IComp2Factory(obj) : null;
        protected readonly ObjectReference<Vftbl> _obj;
        public IObjectReference ObjRef { get => _obj; }
        public IntPtr ThisPtr => _obj.ThisPtr;
        public ObjectReference<I> AsInterface<I>() => _obj.As<I>();
        public A As<A>() => _obj.AsType<A>();
        public IComp2Factory(IObjectReference obj) : this(obj.As<Vftbl>()) { }
        internal IComp2Factory(ObjectReference<Vftbl> obj)
        {
            _obj = obj;
        }

        public unsafe global::Component.Comp2 CreateInstance(int num)
        {
            IntPtr __retval = default;
            try
            {
                global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.CreateInstance_0(ThisPtr, num, out __retval));
                return global::ABI.Component.Comp2.FromAbi(__retval);
            }
            finally
            {
                global::ABI.Component.Comp2.DisposeAbi(__retval);
            }
        }
    }
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public static class IComp2Factory_Delegates
    {
        public unsafe delegate int CreateInstance_0(IntPtr thisPtr, int num, out IntPtr value);
    }

    [global::WinRT.ObjectReferenceWrapper(nameof(_obj))]
    [Guid("CF54A495-6641-5C60-94E7-438846BFB877")]
    public class IComp2Statics : global::Component.IComp2Statics
    {
        [Guid("CF54A495-6641-5C60-94E7-438846BFB877")]
        public struct Vftbl
        {
            internal IInspectable.Vftbl IInspectableVftbl;
            public IComp2Statics_Delegates.GetNum2Multiplier_0 GetNum2Multiplier_0;
            public IComp2Statics_Delegates.GetComp12_1 GetComp12_1;

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
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.IComp2Statics>(thisPtr).GetNum2Multiplier();
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
                global::Component.Comp2 __result = default;

                result = default;

                try
                {
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.IComp2Statics>(thisPtr).GetComp12();
                    result = global::ABI.Component.Comp2.FromManaged(__result);

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

        public static implicit operator IComp2Statics(IObjectReference obj) => (obj != null) ? new IComp2Statics(obj) : null;
        protected readonly ObjectReference<Vftbl> _obj;
        public IObjectReference ObjRef { get => _obj; }
        public IntPtr ThisPtr => _obj.ThisPtr;
        public ObjectReference<I> AsInterface<I>() => _obj.As<I>();
        public A As<A>() => _obj.AsType<A>();
        public IComp2Statics(IObjectReference obj) : this(obj.As<Vftbl>()) { }
        internal IComp2Statics(ObjectReference<Vftbl> obj)
        {
            _obj = obj;
        }

        public unsafe int GetNum2Multiplier()
        {
            int __retval = default;
            global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.GetNum2Multiplier_0(ThisPtr, out __retval));
            return __retval;
        }

        public unsafe global::Component.Comp2 GetComp12()
        {
            IntPtr __retval = default;
            try
            {
                global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.GetComp12_1(ThisPtr, out __retval));
                return global::ABI.Component.Comp2.FromAbi(__retval);
            }
            finally
            {
                global::ABI.Component.Comp2.DisposeAbi(__retval);
            }
        }
    }
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public static class IComp2Statics_Delegates
    {
        public unsafe delegate int GetNum2Multiplier_0(IntPtr thisPtr, out int result);
        public unsafe delegate int GetComp12_1(IntPtr thisPtr, out IntPtr result);
    }

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

    // Will be generated for each component that is activatable and will also implement the statics and factory interfaces.
    public class Comp2ServerActivationFactory : ProductionActivationFactory<Comp2Server>, global::Component.IComp2Factory, global::Component.IComp2Statics
    {
        // Static function, either consumed through another generated static function
        // which handles all classes in this dll or via winrthost directly.
        public static IntPtr Make()
        {
            using var marshaler = MarshalInspectable.CreateMarshaler(_factory).As<IActivationFactory.Vftbl>();
            return marshaler.GetRef();
        }

        static readonly Comp2ServerActivationFactory _factory = new Comp2ServerActivationFactory();
        public static ObjectReference<I> ActivateInstance<I>()
        {
            IntPtr instance = _factory.ActivateInstance();
            return ObjectReference<IInspectable.Vftbl>.Attach(ref instance).As<I>();
        }

        // Had to convert server component to type of wrapper / projected Comp2 object through marshaling.
        public global::Component.Comp2 CreateInstance(int num)
        {
            Comp2Server comp = new Comp2Server(num);
            using var marshaler = MarshalInspectable.CreateMarshaler(comp).As<IComp2.Vftbl>();
            return new global::Component.Comp2(marshaler);
        }

        public int GetNum2Multiplier()
        {
            return Comp2Server.GetNum2Multiplier();
        }

        // Had to convert server component to type of wrapper / projected Comp2 object through marshaling.
        public global::Component.Comp2 GetComp12()
        {
            Comp2Server comp = Comp2Server.GetComp12();
            using var marshaler = MarshalInspectable.CreateMarshaler(comp).As<IComp2.Vftbl>();
            return new global::Component.Comp2(marshaler);
        }
    }
}