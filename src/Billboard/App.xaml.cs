using System;
using System.Threading.Tasks;
using Billboard.Common;
using Billboard.Logic;
using Billboard.Modules.Dashboard;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Billboard
{
    sealed partial class App
    {
        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
            {
                Window.Current.Activate();
                return;
            }

            // Create a Frame to act as the navigation context and associate it with a SuspensionManager key
            var rootFrame = new Frame();
            SuspensionManager.RegisterFrame(rootFrame, "AppFrame");

            if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
            {
                await SuspensionManager.RestoreAsync();
            }

            await DebuggingCleanup();

            var bucketRepository = new BucketRepository(DatabaseConfiguration.Current);
            var userTaskRepository = new UserTaskRepository(DatabaseConfiguration.Current);
            var session = new SessionInitializer(bucketRepository, userTaskRepository);

            await session.Initialize();

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation parameter
                if (!rootFrame.Navigate(typeof(DashboardView)))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            // Place the frame in the current Window and ensure that it is active
            Window.Current.Content = rootFrame;
            Window.Current.Activate();
        }

        private static async Task DebuggingCleanup()
        {
            ApplicationData.Current.LocalSettings.Values.Clear();

            try
            {
                var file = await StorageFile.GetFileFromPathAsync(DatabaseConfiguration.Current.FilePath);
                await file.DeleteAsync(StorageDeleteOption.PermanentDelete);
            }
            catch (Exception)
            {
            }
        }

        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await SuspensionManager.SaveAsync();
            deferral.Complete();
        }
    }
}
