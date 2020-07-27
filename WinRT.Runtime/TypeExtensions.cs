﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace WinRT
{

    public static class TypeExtensions
    {
        public static Type FindHelperType(this Type type)
        {
            if (typeof(Exception).IsAssignableFrom(type))
            {
                type = typeof(Exception);
            }
            Type customMapping = Projections.FindCustomHelperTypeMapping(type);
            if (customMapping is object)
            {
                return customMapping;
            }

            type = type.GetRuntimeClassWrapperType() ?? type;
            var helper = $"ABI.{type.FullName}";
            return Type.GetType(helper) ?? type.Assembly.GetType(helper);
        }

        public static Type GetHelperType(this Type type)
        {
            var helperType = type.FindHelperType();
            if (helperType is object)
                return helperType;
            throw new InvalidOperationException($"Target type is not a projected type: {type.FullName}.");
        }

        public static Type GetGuidType(this Type type)
        {
            return type.IsDelegate() ? type.GetHelperType() : type;
        }

        public static Type FindVftblType(this Type helperType)
        {
            Type vftblType = helperType.GetNestedType("Vftbl");
            if (vftblType is null)
            {
                return null;
            }
            if (helperType.IsGenericType && vftblType is object)
            {
                vftblType = vftblType.MakeGenericType(helperType.GetGenericArguments());
            }
            return vftblType;
        }

        public static Type GetAbiType(this Type type)
        {
            return type.GetHelperType().GetMethod("GetAbi", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static).ReturnType;
        }

        public static Type GetMarshalerType(this Type type)
        {
            return type.GetHelperType().GetMethod("CreateMarshaler", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static).ReturnType;
        }

        public static Type GetRuntimeClassWrapperType(this Type type)
        {
            var wrapperTypeName = $"{type.Namespace}.Impl.{type.Name}";
            return Type.GetType(wrapperTypeName, false) ?? type.Assembly.GetType(wrapperTypeName, false);
        }

        public static bool IsDelegate(this Type type)
        {
            return typeof(Delegate).IsAssignableFrom(type);
        }
    }
}
