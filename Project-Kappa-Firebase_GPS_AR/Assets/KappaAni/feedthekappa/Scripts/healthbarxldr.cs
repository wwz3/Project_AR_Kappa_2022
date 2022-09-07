


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.IO.Ports;
//using System.Threading;
using TechTweaking.Bluetooth;


public class healthbarxldr : MonoBehaviour
{

    //SerialPort stream = new SerialPort("COM3", 9600);
    //private SerialPort arduinoStream;
    // public string port;
    // private Thread readThread;
    public string content;
    bool isNewMessage;
    public static float health = 100, currentstate;
    public double newntu;
    public double ntu;
    public double volt;
    private BluetoothDevice device;
    public Text statusText;
    public ScrollTerminalUI readDataText;//ScrollTerminalUI is a script used to control the ScrollView text


    // Use this for initialization

    const int HEALTHY = 0;
    const int SICK = 1;
    const int DEAD = 2;

    public GameObject player;
    public Slider healthBar;
    //private BluetoothDevice device;
    //public Text statusText;
    // Use this for initialization 

    //Bluetooth related
    //private BluetoothDevice device;
    //public Text dataToSend;
    void Awake()
    {



        BluetoothAdapter.enableBluetooth();//Force Enabling Bluetooth


        device = new BluetoothDevice();

        /*
         * We need to identefy the device either by its MAC Adress or Name (NOT BOTH! it will use only one of them to identefy your device).
         *
         *---------- MacAdress property
         * Using the MAC adress is the best choice because the device doesn't have to be paired/bonded!
         * 
         * ----------Name property
         * Identefy a device by its name using the Property 'BluetoothDevice.Name' require the remote device to be paired
         * but you can try to alter the parameter 'allowDiscovery' of the Connect(int attempts, int time, bool allowDiscovery) method. 
         * allowDiscovery will start a heavy discovery process (if the remote device weren't paired). This will take time 12 to 25 seconds.
         * So it's better to use the 'BluetoothDevice.MacAdress' property. It doesn't need previuos pairing/bonding.
         */


        device.Name = "THESUPERIORONE";
        //device.MacAddress = "XX:XX:XX:XX:XX:XX";

        /*
		 *  Note: The library will fill the properties device.Name and device.MacAdress with the right data after succesfully connecting.
		 * 
		 *  Moreover, any BluetoothDevice instance returned by a method or event of this library will have both properties (Name & MacAdress) filled with the right data
		 */


        //You might need th following:
        //this.device.UUID = UUID; //This is not required for HC-05/06 devices and many other electronic bluetooth modules.
        /*
		 * Quoting docs: A uuid is a Universally Unique Identifier (UUID) standardized 128-bit format for a string ID used to uniquely identify information. 
		 * It's used to uniquely identify your application's Bluetooth service.
		 * Check out getUUIDs(), if you don't know what UUID to use.
		 */

    }




    public void connect()
    {
        statusText.text = "Status : ...";

        /*
		 * Notice that there're more than one connect() method, check out the docs to read about them.
		 * a simple device.connect() is equivalent to connect(3, 1000, false) which will make 3 connection attempts
		 * before failing completly, each attempt will cost at least 1 second = 1000 ms.
		 * -----------
		 * To alter that  check out the following methods in the docs :
		 * connect (int attempts, int time, bool allowDiscovery) 
		 * normal_connect (bool isBrutal, bool isSecure)
		 */
        device.connect();

    }
    public void disconnect()
    {
        device.close();
    }

    // void HandleOnDevicePicked(BluetoothDevice device)//Called when device is Picked by user
    // {

    //     this.device = device;//save a global reference to the device

    //     //this.device.UUID = UUID; //This is only required for Android to Android connection

    //     /* 
    //* setEndByte(10) will change how the read() method works.
    //* 10 equals the char '\n' which is a "new Line" in Ascci representation, 
    //* so the read() method will retun a packet that was ended by the byte 10, without including 10.
    //* Which means read() will read lines while excluding the '\n' new line charachter.
    //* If you don't use the setEndByte() method, device.read() will return any available data (line or not), then you can order/packatize them as you want.
    //* 
    //* Note: setEndByte will make reading lines or packest easier.
    //*/
    //     device.setEndByte(10);


    //     //Assign the 'Coroutine' that will handle your reading Functionality, this will improve your code style
    //     //Other way would be listening to the event Bt.OnReadingStarted, and starting the courotine from there
    //     device.ReadingCoroutine = ManageConnection;

    //   //  devicNameText.text = device.Name;

    // }


    // //############### Reading Data  #####################
    // //Please note that you don't have to use Couroutienes, you can just put your code in the Update() method
    // //If you want to achieve a minimum delay please check the "High Bit Rate Terminal" demo
    // IEnumerator ManageConnection(BluetoothDevice device)
    // {//Manage Reading Coroutine



    //     while (device.IsReading)
    //     {

    //         //polll all available packets
    //         BtPackets packets = device.readAllPackets();

    //         if (packets != null)
    //         {

    //             /*
    //	 * parse packets, packets are ordered by indecies (0,1,2,3 ... N),
    //	 * where Nth packet is the latest packet and 0th is the oldest/first arrived packet.
    //	 * 
    //	 */

    //             for (int i = 0; i < packets.Count; i++)
    //             {

    //                 //packets.Buffer contains all the needed packets plus a header of meta data (indecies and sizes) 
    //                 //To parse a packet we need the INDEX and SIZE of that packet.
    //                 int indx = packets.get_packet_offset_index(i);
    //                 int size = packets.get_packet_size(i);

    //                 string content = System.Text.ASCIIEncoding.ASCII.GetString(packets.Buffer, indx, size);
    //                // readDataText.add(content);
    //             }
    //         }


    //         yield return null;
    //     }
    //Start is called before the first frame update
    void Start()
    {
        //if (port != "")
        //{
        //    arduinoStream = new SerialPort("COM3", 9600); //set port number, the baud rate tally with the serial port
        //    arduinoStream.ReadTimeout = 10;
        //    try
        //    {
        //        arduinoStream.Open(); //start serial port connection
        //        readThread = new Thread(new ThreadStart(ArduinoRead));
        //        readThread.Start();
        //        Debug.Log("SerialPort success");
        //    }
        //    catch
        //    {
        //        Debug.Log("SerialPort failed");
        //    }
        //}
        //else
        //{
        //    Awake();
        //    showDevices();
        //}



    }


    void Update()
    {


        //{
        //    while (device.IsReading)
        //    {

        //        //polll all available packets
        //        BtPackets packets = device.readAllPackets();

        //        if (packets != null)
        //        {

        //            /*
        // * parse packets, packets are ordered by indecies (0,1,2,3 ... N),
        // * where Nth packet is the latest packet and 0th is the oldest/first arrived packet.
        // * 
        // */

        //            for (int i = 0; i < packets.Count; i++)
        //            {

        //                //packets.Buffer contains all the needed packets plus a header of meta data (indecies and sizes) 
        //                //To parse a packet we need the INDEX and SIZE of that packet.
        //                int indx = packets.get_packet_offset_index(i);
        //                int size = packets.get_packet_size(i);

        //                string content = System.Text.ASCIIEncoding.ASCII.GetString(packets.Buffer, indx, size);
        //               // readDataText.add ( content);
        //                ntu = double.Parse(content);

        //               // statusText.text = ntu.ToString();
        //            }
        //        }
        //        yield return null;
        //    }



        if (device.IsReading)
        {


            byte[] msg = device.read();

            if (msg != null)
            {

                //converting byte array to string.
                string content = System.Text.ASCIIEncoding.ASCII.GetString(msg);

                //here we split the string into lines. '\n','\r' are charachter used to represent new line.
                string[] lines = content.Split(new char[] { '\n', '\r' });

                // double p_volt = volt;
                ntu = double.Parse(content); ; //convert content into double from string
                //volt = p_volt * 0.8 + volt * 0.2;

                statusText.text = "MSG : " + ntu.ToString();




                //Add those lines to the scrollText
                /*************
                 * 
                 * THIS IS WHERE U GET DATA
                 * 
                 * /
                readDataText.add(device.Name, lines);

                /* Note: You should notice the possiblity that at the time of calling read() a whole line has not yet completly recieved.
                 * This will split a line into two or more lines between consecutive read() calls. This is not hard to fix, but the goal here is to keep the code simple.
                 * To see a solution using methods of this library check out the "High Bit Rate demo". 
                 */
                //}








                //Debug.Log(readMessage);


                //isNewMessage = false;

                //if (volt < 2.5)
                //{
                //    ntu = 3000;  //3000 will be the maximum value of ntu
                //}
                //else if (volt > 4.2)
                //{
                //    ntu = 0;
                //}
                //else

                //{
                //    ntu = -1120.4 * (volt * volt) + 5742.3 * volt - 4353.8;  //conversion from voltage to ntu
                //}
                //   ntu = double.Parse(content);
                newntu = ((800 - ntu) / 800) * 100;  //convert into health percentage

                //volt = ((3000 - ntu) / 3000) * 100;
                float health = (float)newntu;  //convert double to float
                                               //float health = (float)volt;

                healthBar.value = health;  //health bar displayed as the health percentage


                if (health > 60 && currentstate == SICK)
                {
                    player.GetComponent<Animator>().SetTrigger("isHealthy");
                    currentstate = HEALTHY;
                }



                else if (health <= 60 && health > 25 && currentstate == HEALTHY)
                {
                    player.GetComponent<Animator>().SetTrigger("isSick");
                    currentstate = SICK;
                }



                else if (health <= 25 && currentstate == SICK)
                {
                    player.GetComponent<Animator>().SetTrigger("isDead");
                    currentstate = DEAD;

                    //Instantiate(sos, new Vector3(0, 0, 0), Quaternion.identity);

                }


                else if (health <= 60 && health > 25 && currentstate == DEAD)
                {
                    player.GetComponent<Animator>().SetTrigger("isRecover");
                    currentstate = SICK;
                }

            }
        }


    }
}


//private void ArduinoRead()
//{
//    while (arduinoStream.IsOpen)
//    {
//        try
//        {
//            readMessage = arduinoStream.ReadLine(); // read SerialPort into readMessage
//            isNewMessage = true;

//        }
//        catch (System.Exception e)
//        {
//            Debug.LogWarning(e.Message);
//        }

//    }
//}


//  Update is called once per frame

//        void Update()
//    {
//        if (Input.GetKey("down"))
//        {
//            health = health - 1;
//            healthBar.value = health;
//        }
//        else if (Input.GetKey("up"))
//        {
//            health = health + 1;
//            healthBar.value = health;
//        }
//        //if (volt < 2.5)
//        //{
//        //    ntu = 3000;
//        //}
//        //else
//        //{
//        //    ntu = -1120.4 * (volt * volt) + 5742.3 * volt - 4353.8;
//        //}
//        //newntu = ((3000 - ntu) / 3000) * 100;
//        //health = newntu;

//        if (health > 50 && currentstate == SICK)
//        {
//            player.GetComponent<Animator>().SetTrigger("isHealthy");
//            currentstate = HEALTHY;
//        }



//        else if (health <= 50 && health > 20 && currentstate == HEALTHY)
//        {
//            player.GetComponent<Animator>().SetTrigger("isSick");
//            currentstate = SICK;
//        }



//        else if (health <= 20 && currentstate == SICK)
//        {
//            player.GetComponent<Animator>().SetTrigger("isDead");
//            currentstate = DEAD;

//            Instantiate(sos, new Vector3(0, 0, 0), Quaternion.identity);



//        }




//        else if (health <= 50 && health > 20 && currentstate == DEAD)
//        {
//            player.GetComponent<Animator>().SetTrigger("isRecover");
//            currentstate = SICK;
//        }

//    }
//}


//private void spawnSos()
//{


//    if (health <= 20)
//    {

//        GameObject a = Instantiate(sos) as GameObject;
//        a.transform.position = new Vector3(sos.x, sos.y);
//    }

//}

//public Transform sos;
//public void spawnSos()
//{
//    if (health <= 20)
//    {
//        Instantiate(sos, new Vector3(0, 0, 0), Quaternion.identity);
//    }
//}


//    }
// }
//}

//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using System.IO.Ports;
//using System.Threading;

//public class healthbar : MonoBehaviour

//{
//    SerialPort stream = new SerialPort("COM3", 9600);
//    private SerialPort arduinoStream;
//    public string port;
//    private Thread readThread;
//    public string readMessage;
//    bool isNewMessage;
//    public static float health = 100, currentstate;
//    public double newntu;
//    public double ntu;
//    public double volt;


//    const int HEALTHY = 0;
//    const int SICK = 1;
//    const int DEAD = 2;

//    public GameObject player;
//    public Slider healthBar;

//    //public Transform sos;
//    //public Vector3 sosbutton;
//    //Start is called before the first frame update
//    void Start()
//    {
//        if (port != "")
//        {
//            arduinoStream = new SerialPort("COM3", 9600); //set port number, the baud rate tally with the serial port
//            arduinoStream.ReadTimeout = 10;
//            try
//            {
//                arduinoStream.Open(); //start serial port connection
//                readThread = new Thread(new ThreadStart(ArduinoRead));
//                readThread.Start();
//                Debug.Log("SerialPort success");
//            }
//            catch
//            {
//                Debug.Log("SerialPort failed");
//            }
//        }

//    }

//    void Update()
//    {
//        if (isNewMessage)
//        {
//            Debug.Log(readMessage);
//        }
//        double volt = double.Parse(readMessage); //convert readMessage into double from float
//        isNewMessage = false;

//        if (volt < 2.5)
//        {
//            ntu = 3000;  //3000 will be the maximum value of ntu
//        }
//        else
//        {
//            ntu = -1120.4 * (volt * volt) + 5742.3 * volt - 4353.8;  //conversion from voltage to ntu
//        }

//        newntu = ((3000 - ntu) / 3000) * 100;  //convert into health percentage
//        float health = (float)newntu;  //convert double to float

//        healthBar.value = health;  //health bar displayed as the health percentage


//        if (health > 50 && currentstate == SICK)
//        {
//            player.GetComponent<Animator>().SetTrigger("isHealthy");
//            currentstate = HEALTHY;
//        }



//        else if (health <= 50 && health > 20 && currentstate == HEALTHY)
//        {
//            player.GetComponent<Animator>().SetTrigger("isSick");
//            currentstate = SICK;
//        }



//        else if (health <= 20 && currentstate == SICK)
//        {
//            player.GetComponent<Animator>().SetTrigger("isDead");
//            currentstate = DEAD;

//            //Instantiate(sos, new Vector3(0, 0, 0), Quaternion.identity);

//        }


//        else if (health <= 50 && health > 20 && currentstate == DEAD)
//        {
//            player.GetComponent<Animator>().SetTrigger("isRecover");
//            currentstate = SICK;
//        }

//    }

//    private void ArduinoRead()
//    {
//        while (arduinoStream.IsOpen)
//        {
//            try
//            {
//                readMessage = arduinoStream.ReadLine(); // read SerialPort into readMessage
//                isNewMessage = true;

//            }
//            catch (System.Exception e)
//            {
//                Debug.LogWarning(e.Message);
//            }

//        }
//    }

//}
////  Update is called once per frame

////        void Update()
////    {
////        if (Input.GetKey("down"))
////        {
////            health = health - 1;
////            healthBar.value = health;
////        }
////        else if (Input.GetKey("up"))
////        {
////            health = health + 1;
////            healthBar.value = health;
////        }
////        //if (volt < 2.5)
////        //{
////        //    ntu = 3000;
////        //}
////        //else
////        //{
////        //    ntu = -1120.4 * (volt * volt) + 5742.3 * volt - 4353.8;
////        //}
////        //newntu = ((3000 - ntu) / 3000) * 100;
////        //health = newntu;

////        if (health > 50 && currentstate == SICK)
////        {
////            player.GetComponent<Animator>().SetTrigger("isHealthy");
////            currentstate = HEALTHY;
////        }



////        else if (health <= 50 && health > 20 && currentstate == HEALTHY)
////        {
////            player.GetComponent<Animator>().SetTrigger("isSick");
////            currentstate = SICK;
////        }



////        else if (health <= 20 && currentstate == SICK)
////        {
////            player.GetComponent<Animator>().SetTrigger("isDead");
////            currentstate = DEAD;

////            Instantiate(sos, new Vector3(0, 0, 0), Quaternion.identity);



////        }




////        else if (health <= 50 && health > 20 && currentstate == DEAD)
////        {
////            player.GetComponent<Animator>().SetTrigger("isRecover");
////            currentstate = SICK;
////        }

////    }
////}


////private void spawnSos()
////{


////    if (health <= 20)
////    {

////        GameObject a = Instantiate(sos) as GameObject;
////        a.transform.position = new Vector3(sos.x, sos.y);
////    }

////}

////public Transform sos;
////public void spawnSos()
////{
////    if (health <= 20)
////    {
////        Instantiate(sos, new Vector3(0, 0, 0), Quaternion.identity);
////    }
////}


////    }
//// }
////}
