using Dynamo.Models;
using Dynamo.Wpf.ViewModels.Watch3D;

namespace DynamoPilot.App.Models
{
    public class NullWatch3DViewModel : DefaultWatch3DViewModel
    {
        public NullWatch3DViewModel(DynamoModel model)
            : base(null, new Watch3DViewModelStartupParams(model))
        {
            Active = false;
        }
    }
}
