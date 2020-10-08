namespace AzureDevOpsTools.Framework.Windows
{
    public interface IManagedWindow
    {
#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.

        void Show();
        object? DataContext { get; set; }
        void Close();

#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
    }
}
