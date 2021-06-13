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
 * 
  namespace Component
  {
   public class Comp
   {
       public Comp()
       {
           _num = 5;
        }

        public int GetNumber()
        {
            return _num;
        }

        private int _num;
    }
  }
 * 
 * An IDL / WinMD which would be auto generated would look something like the following.
 * 
   namespace Component
   {
       runtimeclass Comp
       {
           Comp();
           Int32 GetNumber();
       }
   }
 */

namespace Component
{
    // Note the rename of the class and the addition of inheriting default interface.
    // Still need to investigate what we do about any interfaces the component
    // previously implemented (i.e. whether they are projected for QI).
    public class CompServer : global::Component.IComp
    {
        public CompServer()
        {
            _num = 5;
        }

        public int GetNumber()
        {
            return _num;
        }

        private int _num;
    }
}

#pragma warning disable 0169 // warning CS0169: The field '...' is never used
#pragma warning disable 0649 // warning CS0169: Field '...' is never assigned to

namespace Component
{

    // This is what a C# consumer would reference to consume this component.
    // There is currently a projection indirection but we can optimize this in the future
    // to elimainate some of that once we have something working.
    [global::WinRT.WindowsRuntimeType]
    [global::WinRT.ProjectedRuntimeClass(nameof(_default))]
    [Windows.Foundation.Metadata.Activatable(1u)]
    [Windows.Foundation.Metadata.MarshalingBehavior(global::Windows.Foundation.Metadata.MarshalingType.Agile)]
    [Windows.Foundation.Metadata.Threading(global::Windows.Foundation.Metadata.ThreadingModel.Both)]
    [Windows.Foundation.Metadata.Version(1u)]
    public sealed class Comp : global::System.Runtime.InteropServices.ICustomQueryInterface, IEquatable<Comp>
    {
        public IntPtr ThisPtr => _default.ThisPtr;

        private IObjectReference _inner = null;
        private readonly Lazy<global::ABI.Component.IComp> _defaultLazy;
        private readonly Dictionary<Type, object> _lazyInterfaces;

        private global::ABI.Component.IComp _default => _defaultLazy.Value;

        // Note the updated call for ActivationFactory.
        public Comp() : this(new global::ABI.Component.IComp(CompServerActivationFactory.ActivateInstance<global::ABI.Component.IComp.Vftbl>()))
        {
            // Note I commented this out as I wasn't exactly sure on the impact on registering an object when one already exists.
            // Experimentation showed it might be fine to not comment it as internally it is a GetorAdd type function, but requires futher investigation
            //  ComWrappersSupport.RegisterObjectForInterface(this, ThisPtr);
        }

        public static Comp FromAbi(IntPtr thisPtr)
        {
            if (thisPtr == IntPtr.Zero) return null;
            var obj = MarshalInspectable.FromAbi(thisPtr);
            return obj is Comp ? (Comp)obj : new Comp((global::ABI.Component.IComp)obj);
        }

        internal Comp(global::ABI.Component.IComp ifc)
        {
            _defaultLazy = new Lazy<global::ABI.Component.IComp>(() => ifc);
            _lazyInterfaces = new Dictionary<Type, object>()
            {
            };
        }

        public static bool operator ==(Comp x, Comp y) => (x?.ThisPtr ?? IntPtr.Zero) == (y?.ThisPtr ?? IntPtr.Zero);
        public static bool operator !=(Comp x, Comp y) => !(x == y);
        public bool Equals(Comp other) => this == other;
        public override bool Equals(object obj) => obj is Comp that && this == that;
        public override int GetHashCode() => ThisPtr.GetHashCode();

        private IObjectReference GetDefaultReference<T>() => _default.AsInterface<T>();
        private IObjectReference GetReferenceForQI() => _inner ?? _default.ObjRef;

        private struct InterfaceTag<I> { };

        private IComp AsInternal(InterfaceTag<IComp> _) => _default;

        public int GetNumber() => _default.GetNumber();

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
    [Guid("4AD29369-D636-58CC-B4A5-0DFC5389CFD5")]
    [Windows.Foundation.Metadata.ExclusiveTo(typeof(Comp))]
    [Windows.Foundation.Metadata.Version(1u)]
    internal interface IComp
    {
        int GetNumber();
    }

    // This will probably live in a common place like winrt.runtime.
    [global::WinRT.WindowsRuntimeType]
    [Guid("00000035-0000-0000-C000-000000000046")]
    [Windows.Foundation.Metadata.Version(1u)]
    internal interface IActivationFactory
    {
        IntPtr ActivateInstance();
    }

}

namespace ABI.Component
{
    // This is identical to what CsWinRT generates today for the above idl.  We can
    // probably call CsWinRT to generate it.
    [global::WinRT.ObjectReferenceWrapper(nameof(_obj))]
    [Guid("4AD29369-D636-58CC-B4A5-0DFC5389CFD5")]
    public class IComp : global::Component.IComp
    {
        [Guid("4AD29369-D636-58CC-B4A5-0DFC5389CFD5")]
        public struct Vftbl
        {
            internal IInspectable.Vftbl IInspectableVftbl;
            public IComp_Delegates.GetNumber_0 GetNumber_0;

            private static readonly Vftbl AbiToProjectionVftable;
            public static readonly IntPtr AbiToProjectionVftablePtr;
            static unsafe Vftbl()
            {
                AbiToProjectionVftable = new Vftbl
                {
                    IInspectableVftbl = global::WinRT.IInspectable.Vftbl.AbiToProjectionVftable,
                    GetNumber_0 = Do_Abi_GetNumber_0
                };
                var nativeVftbl = (IntPtr*)ComWrappersSupport.AllocateVtableMemory(typeof(Vftbl), Marshal.SizeOf<global::WinRT.IInspectable.Vftbl>() + sizeof(IntPtr) * 1);
                Marshal.StructureToPtr(AbiToProjectionVftable, (IntPtr)nativeVftbl, false);
                AbiToProjectionVftablePtr = (IntPtr)nativeVftbl;
            }

            private static unsafe int Do_Abi_GetNumber_0(IntPtr thisPtr, out int result)
            {
                int __result = default;

                result = default;

                try
                {
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.IComp>(thisPtr).GetNumber();
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

        public static implicit operator IComp(IObjectReference obj) => (obj != null) ? new IComp(obj) : null;
        protected readonly ObjectReference<Vftbl> _obj;
        public IObjectReference ObjRef { get => _obj; }
        public IntPtr ThisPtr => _obj.ThisPtr;
        public ObjectReference<I> AsInterface<I>() => _obj.As<I>();
        public A As<A>() => _obj.AsType<A>();
        public IComp(IObjectReference obj) : this(obj.As<Vftbl>()) { }
        internal IComp(ObjectReference<Vftbl> obj)
        {
            _obj = obj;
        }

        public unsafe int GetNumber()
        {
            int __retval = default;
            global::WinRT.ExceptionHelpers.ThrowExceptionForHR(_obj.Vftbl.GetNumber_0(ThisPtr, out __retval));
            return __retval;
        }
    }
    [global::System.ComponentModel.EditorBrowsable(global::System.ComponentModel.EditorBrowsableState.Never)]
    public static class IComp_Delegates
    {
        public unsafe delegate int GetNumber_0(IntPtr thisPtr, out int result);
    }

    // Note that this only has the vtable (Do_*) side of the projection as
    // I optimized the activation factory to consume the APIs directly rather than via Vtable.
    // But based on how we decide to generate the activation factories, we can go either route (optimized or not optimized with redirection).
    // And given this is a common class, this can live in winrt.runtime.
    [Guid("00000035-0000-0000-C000-000000000046")]
    public class IActivationFactory
    {
        [Guid("00000035-0000-0000-C000-000000000046")]
        public struct Vftbl
        {
            public unsafe delegate int _ActivateInstance(IntPtr pThis, out IntPtr instance);

            internal IInspectable.Vftbl IInspectableVftbl;
            public _ActivateInstance ActivateInstance;

            private static readonly Vftbl AbiToProjectionVftable;
            public static readonly IntPtr AbiToProjectionVftablePtr;
            static unsafe Vftbl()
            {
                AbiToProjectionVftable = new Vftbl
                {
                    IInspectableVftbl = global::WinRT.IInspectable.Vftbl.AbiToProjectionVftable,
                    ActivateInstance = Do_Abi_ActivateInstance
                };
                var nativeVftbl = (IntPtr*)ComWrappersSupport.AllocateVtableMemory(typeof(Vftbl), Marshal.SizeOf<global::WinRT.IInspectable.Vftbl>() + sizeof(IntPtr) * 1);
                Marshal.StructureToPtr(AbiToProjectionVftable, (IntPtr)nativeVftbl, false);
                AbiToProjectionVftablePtr = (IntPtr)nativeVftbl;
            }

            private static unsafe int Do_Abi_ActivateInstance(IntPtr thisPtr, out IntPtr result)
            {
                IntPtr __result = default;

                result = default;

                try
                {
                    __result = global::WinRT.ComWrappersSupport.FindObject<global::Component.IActivationFactory>(thisPtr).ActivateInstance();
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
    }

    public class ProductionActivationFactory<T> : global::Component.IActivationFactory where T : class, new()
    {
        public IntPtr ActivateInstance()
        {
            T comp = new T();
            using var marshaler = MarshalInspectable.CreateMarshaler(comp);
            return marshaler.GetRef();
        }
    }

    // Will be generated for each component that is activatable and will also implement the statics and factory interfaces.
    public class CompServerActivationFactory : ProductionActivationFactory<CompServer>
    {
        // Static function, either consumed through another generated static function
        // which handles all classes in this dll or via winrthost directly.
        public static IntPtr Make()
        {
            using var marshaler = MarshalInspectable.CreateMarshaler(_factory).As<IActivationFactory.Vftbl>();
            return marshaler.GetRef();
        }

        static readonly CompServerActivationFactory _factory = new CompServerActivationFactory();
        public static ObjectReference<I> ActivateInstance<I>()
        {
            IntPtr instance = _factory.ActivateInstance();
            return ObjectReference<IInspectable.Vftbl>.Attach(ref instance).As<I>();
        }
    }
}