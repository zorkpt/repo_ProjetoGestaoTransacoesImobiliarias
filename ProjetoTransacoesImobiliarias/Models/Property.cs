using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.WebSockets;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;
using ProjetoTransacoesImobiliarias.Controllers;

namespace ProjetoTransacoesImobiliarias.Models;

public class Property
{
    private static int _counter = 0;
    public int Id { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public PropertyType PropertyType { get; set; }
    public bool ForSale { get; set; }
    public double SquareMeters { get; set; }
    public int ClientId { get; set; }
    public Client Client { get; set; }
    public int AddedById { get; set; }
    public User AddedBy { get; set; }
    
    
    [JsonConstructor]
    public Property(int id, string address, string description, PropertyType propertyType, double squareMeters, int addedById, bool forSale, int clientId)
    {
        Id = id;
        Address = address;
        Description = description;
        PropertyType = propertyType;
        SquareMeters = squareMeters;
        AddedById = addedById;
        ForSale = forSale;
        ClientId = clientId;
    }

    
    public Property(string address, string description,
        PropertyType propertyType, double size, User addedBy, Client client)
    {
        Address = address;
        Description = description;
        PropertyType = propertyType;
        SquareMeters = size;
        Client = client;
        AddedBy = addedBy;
        ForSale = true;
    }

    public void SetAddedBy(User user)
    {
        AddedBy = user;
    }
    
    public void SetClient(Client client)
    {
        Client = client;
    }
    
}