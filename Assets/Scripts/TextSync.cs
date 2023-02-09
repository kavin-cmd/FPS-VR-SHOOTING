using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

namespace VelNet
{
    public class TextSync : NetworkSerializedObjectStream
    {
        [AddComponentMenu("VelNet/VelNet Sync Transform")]
        // Start is called before the first frame update

        protected override void SendState(BinaryWriter writer)
        {
            writer.Write(transform.GetComponent<TextMeshProUGUI>().text);
        }

        protected override void ReceiveState(BinaryReader reader)
        {
            transform.GetComponent<TextMeshProUGUI>().text = reader.ReadString();
        }
    }
}