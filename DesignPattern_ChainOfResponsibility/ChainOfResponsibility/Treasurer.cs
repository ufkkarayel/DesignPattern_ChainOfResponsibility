using DesignPattern_ChainOfResponsibility.DAL.Context;
using DesignPattern_ChainOfResponsibility.DAL.Entities;
using DesignPattern_ChainOfResponsibility.Models;

namespace DesignPattern_ChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer : Employee
    {

        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            ChainOfResContext context = new ChainOfResContext();
            if (req.Amount <= 100000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.Name = req.Name;
                customerProcess.Description = "Müşterinin talep ettiği kredi tutarı tarafımca ödenmiştir.";
                customerProcess.EmployeeName = "Veznedar Ali Yıldız";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount;
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Veznedar Ali Yıldız";
                customerProcess.Description = "Müşterinin talep ettiği tutar ödenemediği için şube müdür yardımcısına aktarılmıştır.";
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }

        }
    }
}
