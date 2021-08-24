//-----------------------------------------------------------------------
// <copyright file="GlobalSuppressions.cs" company="Brian Welsh, welshnson.com">
//     Copyright (c) Brian Welsh, welshnson.com. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "Build",
    "CA1812:AboutApplicaitonViewModel is an internal class that is apparently never instantiated. If so, remove the code from the assembly. If this class is intended to contain only static members, make it static (Shared in Visual Basic).",
    Justification = "Reviewed - Instantiated via mef",
    Scope = "type",
    Target = "~T:AzureDevOpsTools.Presentation.ViewModels.AboutApplicaitonViewModel")]

[assembly: SuppressMessage(
    "Build",
    "CA1812:MainViewModel is an internal class that is apparently never instantiated. If so, remove the code from the assembly. If this class is intended to contain only static members, make it static (Shared in Visual Basic).",
    Justification = "Reviewed - Instantiated via mef",
    Scope = "type",
    Target = "~T:AzureDevOpsTools.Presentation.ViewModels.MainViewModel")]
