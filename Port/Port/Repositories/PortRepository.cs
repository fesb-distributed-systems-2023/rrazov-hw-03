/*
**********************************
* Author: Roko Ražov
* Project Task: Port - Phase 2
**********************************
* Description:
*  
*  Implement `IPortRepository` interface
*
**********************************
*/



using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Port.Models;



namespace Port.Repositories
{
    public class PortRepository
    {
        private List<Ports> m_lstPort;
        public PortRepository() 
        {
            m_lstPort = new List<Ports>();   
        }

        public bool CreateNewPort(Ports port)
        {
            m_lstPort.Add(port);

            return true;
        }

        public IEnumerable<Ports> GetAllPorts() 
        {
            return m_lstPort;
        }

        public Ports GetPortById(int id) 
        {
            if(!m_lstPort.Any(port => port.Id == id))
            {
                return null;
            }
            var port = m_lstPort.FirstOrDefault(port => port.Id == id);

            return port;
        }

        public bool DeletePort(int id) 
        {
            var itemToDelete = m_lstPort.FirstOrDefault(itemPort => itemPort.Id == id);
            if (itemToDelete == null) 
            {
                return false;
            }

            m_lstPort.Remove(itemToDelete);

            return true;
        }
    }
}
