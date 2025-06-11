using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Toolbox.Infrastructure;
using Toolbox.Infrastructure.Mappings;
using Toolbox.Infrastructure.Mappings.Toolbox.Infrastructure.Mappings;

namespace Toolbox
{


        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();

                // Create dependencies manually
                var httpClient = new HttpClient();

                var dbContext = new ToolboxDbContext();

                var config = new MapperConfiguration(cfg => cfg.AddProfile<OllamaMappingProfile>());
                var mapper = config.CreateMapper();

                // Create services
                var ollamaService = new OllamaService(httpClient, dbContext, mapper);
                var viewModel = new ChatViewModel(ollamaService);

                DataContext = viewModel;
            }
        }
    

}