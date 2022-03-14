using AgileManagementSystem.Core.Domain;
using AgileManagementSystem.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagementSystem.Domain.Models
{
    public class Project : Entity
    {
        public string Name { get; private set; }
        public string Description { get; set; }

        private List<Contributor> _contributors = new List<Contributor>();
        public IReadOnlyCollection<Contributor> Contributors => _contributors;
        private List<ProductBacklogItem> _productBacklog = new();
        public IReadOnlyCollection<ProductBacklogItem> ProductBacklog => _productBacklog;

        public string CreatedBy { get; private set; }



        public Project(string name, string description, string createdBy)
        {
            Id = Guid.NewGuid().ToString();
            SetName(name);
            Description = description;
            CreatedBy = createdBy;
        }

        /// <summary>
        /// Projeye isim verildikten sonra bir daha proje ismi değişemez.
        /// </summary>
        /// <param name="name"></param>
        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Proje ismi giriniz");
            }

            Name = $"{name.Trim()}-{DateTime.Now.ToString("d")}";

        }



        /// <summary>
        /// Projeye contributor ekleme işlemi olsun
        /// </summary>
        /// <param name="contributor"></param>
        public void AddContributor(Contributor contributor)
        {

            // Projeye dahil etme isteğinde bulunduk
            // eğer kullanıcı mail adresinden isteği kabul et butonuna basarsa bu durumda projede contributor olarak görünebilecek ve projeye erişm izni olacak.

            if (_contributors.Any(x => x.Email == contributor.Email))
            {
                throw new Exception("Aynı user aynı projeye contritor olarak eklenemez");
            }
            else
            {
                // aynı contributor eklenemez
                // contibuter eklenirken contributor state waitingforrequest olarak ayalarnır.
                _contributors.Add(contributor);
                //DomainEvent.Raise(new ContributorSendAccessRequestEvent(this.Name, this.Id));
            }


        }

        /// <summary>
        /// Yanlışlıkla eklenen bir kullanıcıyı projeden geri aldık
        /// </summary>
        /// <param name="contributor"></param>
        public void RemoveContributor(Contributor contributor)
        {
            _contributors.Remove(contributor);
            //DomainEvent.Raise(new ContributorRevokeAccessEvent(this.Name, contributor.UserId));
        }

    }
}
