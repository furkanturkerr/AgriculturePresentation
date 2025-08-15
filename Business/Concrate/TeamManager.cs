using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrate;

namespace Business.Concrate;

public class TeamManager : ITeamService 
{
    private readonly ITeamDal _teamDal;
    
    public TeamManager(ITeamDal teamDal)
    {
        _teamDal = teamDal;
    }

    public void Insert(Team t)
    {
        _teamDal.Insert(t);
    }

    public void Update(Team t)
    {
        _teamDal.Update(t);
    }

    public void Delete(Team t)
    {
        _teamDal.Delete(t);   
    }

    public Team GetById(int id)
    {
        return _teamDal.GetById(id);
    }

    public List<Team> GetAll()
    {
        return _teamDal.GetAll();       
    }
}