using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSender.lib.Data.Linq2SQL;

namespace MailSender.lib.Serveses
{
    public class RecipientsDataProvider
    {
        private readonly MailSenderDBDataContext _db;
        public RecipientsDataProvider(MailSenderDBDataContext db)
        {
            _db = db;
        }

        public IEnumerable<Recipients> GetAll() => _db.Recipients.ToArray();
    }
}
