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
            UserEntity objUserEntity = UserEntity.GetInstance();
            ChannelOrdersModel objOrdModel = new ChannelOrdersModel();
            string strFromDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
            List<string> statusList = new List<string>();
            //objOrdModel.GetOrders(objUserEntity, strFromDate, "", statusList);


        }
    }
}