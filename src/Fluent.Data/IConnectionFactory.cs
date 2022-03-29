// Copyright (c) Alexander Bocharov. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Fluent.Data;

public interface IConnectionFactory
{
    IDbConnection CreateConnection();
    Type DbConnectionType { get; }
}
