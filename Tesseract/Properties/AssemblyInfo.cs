#region Using directives

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

#endregion

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("TesseractOcr")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("TesseractOcr")]
[assembly: AssemblyCopyright("Copyright 2012")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// This sets the default COM visibility of types in the assembly to invisible.
// If you need to expose a type to COM, use [ComVisible(true)] on that type.
[assembly: ComVisible(false)]

#if NETSTANDARD2_0
// Ensure internals are visible to the test assembly so we can test them too.
[assembly: InternalsVisibleTo("Tesseract.Tests")]
#endif

// Versioning is handled by AssemblyVersionInfo.cs
