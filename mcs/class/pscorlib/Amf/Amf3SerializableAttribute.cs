// IAmf3Serializable.cs
//
// Copyright (c) 2009 Chris Howie
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.IO;

namespace Amf
{
	// the Amf3Serializable attribute is applied to a class when it implements IAmf3Serializable and has its own instance methods that do serialization:
	// [Amf3Serializable("MyClass"]
	// public class MyClass : IAmf3Serializable {
	//		public void Serialize(Amf3Writer writer) { ... }
	//		public void Serialize(Amf3Reader reader) { ... }
	// }
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class Amf3SerializableAttribute : Attribute
	{
		public string ClassName { get; private set; }

		public Amf3SerializableAttribute(string className = null)
		{
			ClassName = className;
		}
	}

	// the Amf3Serializer attribute is applied to a class implementing the IAmf3Serializer interfaces
	// this class can be used to serialize another class by providing read/write/construct methods 
	// [Amf3Serializer("MyClass", typeof(MyClass)]
	// public class MySerializerClass : IAmf3Serializer {
	//	public object NewInstance(Amf3ClassDef classDef);
	// 	public IList  NewVector(uint num, bool isFixed);
	// 	public void   WriteObject(Amf3Writer writer, object obj);
	// 	public void   ReadObject(Amf3Parser parser, Amf3ClassDef classDef, object obj);	
	// }

	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class Amf3SerializerAttribute : Attribute
	{
		public string ClassName { get; private set; }
		public Type TargetType { get; private set; }

		public Amf3SerializerAttribute(string className, Type targetType)
		{
			ClassName = className;
			TargetType = targetType;
		}
	}

}
