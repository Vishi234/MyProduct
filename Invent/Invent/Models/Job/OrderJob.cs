using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using Quartz;
using Invent.Models.BAL.Order;
using Invent.Models.Entity.User;

namespace Invent.Models.Job
{
    public class OrderJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            UserEntity objUserEntity = new UserEntity();
            ChannelOrdersModel objOrdModel = new ChannelOrdersModel();
            DateTime now = DateTime.Now;
            var strFromDate = new DateTime(now.Year, now.Month, 1);
            List<string> statusList = new List<string>();
            string response = objOrdModel.GetOrders(objUserEntity, strFromDate.ToString(), "", statusList);


        }
    }
}