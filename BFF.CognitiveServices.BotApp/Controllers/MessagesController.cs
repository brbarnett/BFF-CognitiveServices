using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using BFF.CognitiveServices.BotApp.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;

namespace BFF.CognitiveServices.BotApp.Controllers
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        internal static IDialog<SandwichOrder> MakeRootDialog()
        {
            return Chain.From(() => FormDialog.FromForm(SandwichOrder.BuildForm));
        }

        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                await Conversation.SendAsync(activity, MakeRootDialog);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}