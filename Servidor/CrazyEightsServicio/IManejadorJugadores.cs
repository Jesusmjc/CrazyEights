﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataAccesss;

namespace CrazyEightsServicio
{
    [ServiceContract]
    public interface IManejadorJugadores
    {
        [OperationContract]
        //int GuardarJugador(Usuario usuario, Jugador jugador);

        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "CrazyEightsServicio.ContractType".
   
    //To Do
    [DataContract]
    public class Jugador
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}