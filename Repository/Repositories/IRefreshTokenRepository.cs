﻿using Domain.Entities;

namespace Repository.Repositories;

public interface IRefreshtokenRepository
{
    Task<RefreshToken> GetStoredRefreshToken(string refreshToken);
    Task SaveRefreshToken(RefreshToken refreshToken);
}
