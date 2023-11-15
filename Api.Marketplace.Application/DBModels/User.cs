﻿namespace Api.Marketplace.Application.DBModels;

public class User 
{
    public User(string username, string externalUserId)
    {
        Username = username;
        ExternalUserId = externalUserId;
        Listings = new List<Listing>();
    }

    public int UserId { get; set; }
    public string Username { get; set; }
    public string ExternalUserId { get; set; }
    public virtual ICollection<Listing> Listings { get; set; }
}
