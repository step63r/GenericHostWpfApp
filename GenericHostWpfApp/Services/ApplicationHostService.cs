using GenericHostWpfApp.Windows;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace GenericHostWpfApp.Services
{
    /// <summary>
    /// アプリケーションのマネージドホスト
    /// </summary>
    /// <param name="applicationLifetime">IHostApplicationLifetime</param>
    /// <param name="serviceProvider">IServiceProvider</param>
    internal class ApplicationHostService(IHostApplicationLifetime applicationLifetime, IServiceProvider serviceProvider) : IHostedService
    {
        #region インターフェイス
        /// <summary>
        /// IHostApplicationLifetime
        /// </summary>
        private readonly IHostApplicationLifetime _applicationLifetime = applicationLifetime;

        /// <summary>
        /// IServiceProvider
        /// </summary>
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        #endregion

        #region メンバ変数
        /// <summary>
        /// Window
        /// </summary>
        private Window _window;
        #endregion

        #region IHostedService
        /// <summary>
        /// サービスが開始するときにトリガーされるメソッド
        /// </summary>
        /// <param name="cancellationToken">キャンセルトークン</param>
        /// <returns>実行結果</returns>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await HandleActivateAsync();
        }

        /// <summary>
        /// サービスが終了するときにトリガーされるメソッド
        /// </summary>
        /// <param name="cancellationToken">キャンセルトークン</param>
        /// <returns>実行結果</returns>
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
        #endregion

        /// <summary>
        /// HandleActivateAsync
        /// </summary>
        /// <returns></returns>
        private async Task HandleActivateAsync()
        {
            if (!Application.Current.Windows.OfType<MainWindow>().Any())
            {
                _window = (_serviceProvider.GetService(typeof(MainWindow)) as MainWindow)!;
                _window!.Show();
            }

            await Task.CompletedTask;
        }
    }
}
