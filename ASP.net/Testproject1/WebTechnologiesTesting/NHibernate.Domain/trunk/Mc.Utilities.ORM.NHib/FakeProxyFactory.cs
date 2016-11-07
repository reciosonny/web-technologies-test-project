//  David Newman <newman.de@gmail.com>
//
// Copyright (C) 2010 David Newman
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NHibernate;

namespace Mc.ORM.NHib.Util
{
    /// <summary>
    /// This class is used to replace the IProxyFactoryFactory implementation specified by
    /// the NHibernate config file.  This way clients of the library don't need a binary
    /// dependency on any actual implementation.
    /// </summary>
    internal class FakeProxyFactoryFactory : global::NHibernate.Bytecode.IProxyFactoryFactory
    {
        #region IProxyFactoryFactory Members

        public global::NHibernate.Proxy.IProxyFactory BuildProxyFactory()
        {
            return new FakeProxyFactory();
        }

        public global::NHibernate.Proxy.IProxyValidator ProxyValidator
        {
            get { return new FakeProxyValidator(); }
        }

        #endregion
    }

    /// <summary>
    /// Used in place of any real IProxyFactory implementation.
    /// </summary>
    internal class FakeProxyFactory : global::NHibernate.Proxy.IProxyFactory
    {

        #region IProxyFactory Members

        public global::NHibernate.Proxy.INHibernateProxy GetProxy(object id, global::NHibernate.Engine.ISessionImplementor session)
        {
            throw new NotImplementedException("GetProxy");
        }

        public void PostInstantiate(string entityName, Type persistentClass, Iesi.Collections.Generic.ISet<Type> interfaces, System.Reflection.MethodInfo getIdentifierMethod, System.Reflection.MethodInfo setIdentifierMethod, global::NHibernate.Type.IAbstractComponentType componentIdType)
        {
            
        }

        #endregion
    }

    /// <summary>
    /// Used to replace any real IProxyValidator implementation
    /// </summary>
    internal class FakeProxyValidator : global::NHibernate.Proxy.IProxyValidator
    {

        #region IProxyValidator Members

        public bool IsProxeable(System.Reflection.MethodInfo method)
        {
            return true;
        }

        public ICollection<string> ValidateType(Type type)
        {
            return null;
        }

        #endregion
    }
}
