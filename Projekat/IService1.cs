using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Projekat
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(ITemperatureSensorCallback))]
    public interface IService1
    {
        [OperationContract]
        void StartSensors();

        [OperationContract]
        void StopSensors();

        [OperationContract]
        void AlignReplicas();

        [OperationContract]
        void Subscribe();
    }

    public interface ITemperatureSensorCallback
    {
        [OperationContract]
        void NotifyTemperature(int sensorId, double temperature);
        [OperationContract]
        void AlignReplicasCallback(object state);
    }

}
