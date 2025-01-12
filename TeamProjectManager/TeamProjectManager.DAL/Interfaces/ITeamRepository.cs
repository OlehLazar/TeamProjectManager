﻿using TeamProjectManager.DAL.Entities;

namespace TeamProjectManager.DAL.Interfaces;

public interface ITeamRepository : IRepository<Team>
{
	Task<IEnumerable<Team>> GetAllByUserId(string userId);
}
