﻿namespace API.Contracts;

public sealed record LoginRequest(
    string Email,
    string Password);
