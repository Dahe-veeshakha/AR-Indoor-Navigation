using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.Networking;

public class CertificateWhore : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        return true;
    }

    //var request = UnityWebRequest.Delete(API + aCommand);
    //    request.CertificateHandler = new CertificateWhore();
}
