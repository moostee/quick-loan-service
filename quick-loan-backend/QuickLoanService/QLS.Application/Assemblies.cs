﻿namespace QLS.Application
{
    using System.Reflection;
    using QLS.Application.Commands;

    public static class Assemblies
    {
        public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;
    }
}
