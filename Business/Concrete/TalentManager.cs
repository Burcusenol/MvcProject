using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TalentManager : ITalentService
    {
        ITalentDal _talentDal;

        public TalentManager(ITalentDal talentDal)
        {
            _talentDal = talentDal;
        }

        public void Delete(Talent talent)
        {
            _talentDal.Delete(talent);
        }

        public Talent GetById(int id)
        {
            return _talentDal.Get(t => t.TalentId == id);
        }

        public List<Talent> GetTalents()
        {
            return _talentDal.GetAll();
        }

        public void Insert(Talent talent)
        {
            _talentDal.Insert(talent);
        }

        public void Update(Talent talent)
        {
            _talentDal.Update(talent);
        }
    }
}
