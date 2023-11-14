using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using Microsoft.VisualBasic;
using ProjetoTransacoesImobiliarias.Controllers;
namespace ProjetoTransacoesImobiliarias.Models;

public class Property
{
    private static int _counter = 0;
    private string _address {get; set;}
    private string _description {get; set;}
    private PropertyType _propertyType {get; set;}
    private bool _forSale {get; set;}
    private double _squareMeters {get; set;}
    private int _clientId {get; set;}
    private int _userId {get; set;}



    public Property(string address, string description, 
                                PropertyType propertyType, double size, 
                                int addedBy, int owner){
        _address = address;
        _description = description;
        _propertyType = propertyType;
        _squareMeters = size;
        _clientId = owner;
        _userId = addedBy;
        _forSale = true;
    }



}