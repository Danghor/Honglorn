﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.34014
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Globalization
Imports System.Resources
Imports System.Runtime.CompilerServices

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), _
     DebuggerNonUserCode(), _
     CompilerGenerated(), _
     HideModuleName()> _
    Friend Module Resources

        Private resourceMan As ResourceManager

        Private resourceCulture As CultureInfo

        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Friend ReadOnly Property ResourceManager() As ResourceManager
            Get
                If ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As ResourceManager = New ResourceManager("HonglornTest.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property

        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <EditorBrowsable(EditorBrowsableState.Advanced)> _
        Friend Property Culture() As CultureInfo
            Get
                Return resourceCulture
            End Get
            Set(ByVal value As CultureInfo)
                resourceCulture = value
            End Set
        End Property
    End Module
End Namespace
