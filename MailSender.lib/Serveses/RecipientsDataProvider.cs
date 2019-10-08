using System;
using System.Collections.Generic;
using System.Data.Linq;
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

        public IEnumerable<Recipients> GetAll()
        {
            _db.Refresh(RefreshMode.OverwriteCurrentValues);
            return _db.Recipients.ToArray();
        }

        public int Create(Recipients recipient)
        {
            if (recipient is null) throw new ArgumentNullException(nameof(recipient));

            _db.Recipients.InsertOnSubmit(recipient);
            SaveChanges();
            return recipient.Id;
        }

        public void SaveChanges()
        {
            _db.SubmitChanges();
        }
    }
}
