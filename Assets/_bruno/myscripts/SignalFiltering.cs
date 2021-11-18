using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

using brainflow;
using brainflow.math;



    public class SignalFiltering: MonoBehaviour
    {
        public static double[,] unprocessed_data = null;
        public static double[,] empty_data;

        public static double [] filtered;
        /*
        public static double[] filtered5;
        public static double[] filtered12;
        public static double[] filtered19;
        public static double[] filtered25;
        */
        public static String enemySelected;

        //public GameObject textObject;

        public TextMeshProUGUI enSel;
        void Awake(){

            print("SignalFiltering Started");
            DontDestroyOnLoad(this.gameObject);
            //enSel = textObject.GetComponent<TextMeshProUGUI> ();
        }

        void Update ()
        {
            if(unprocessed_data!=null){
                //THIS FUNCTION WAS MAINLY TESTED WITH THE SYNTHETIC BOARD
                int board_id = staticPorts.boardIdSelected;
                
                int[] eeg_channels = staticPorts.eeg_channels;
                
                
                if (unprocessed_data.GetLength(1) % (staticPorts.sampling_rate*2) == 0){
                    
                    print("ENTERED THE IF");
                    for (int i = 0; i < eeg_channels.Length; i++){
                        
                        //FILTERING THE SIGNAL WITH NOTCH AND BANDPASS FILTER
                        filtered = DataFilter.remove_environmental_noise(unprocessed_data.GetRow (eeg_channels[i]),staticPorts.sampling_rate,(int)NoiseTypes.FIFTY);
                        filtered = DataFilter.perform_bandpass(unprocessed_data.GetRow(eeg_channels[i]),staticPorts.sampling_rate,10.0,3.0,2,(int)FilterTypes.BUTTERWORTH, 0.0);
                        
                    }
                    print(filtered.GetLength(0));
                }
            

                /*
                double sum5 = 0,sum12 = 0, sum19 = 0, sum25 = 0;
                for(int j = 0;j < filtered5.Length;j++){
                    sum5 = sum5 + filtered5[j];
                    sum12 = sum12 + filtered12[j];
                    sum19 = sum19 + filtered19[j];
                    sum25 = sum25 + filtered25[j];
                }
                print(sum5/filtered5.Length);
                
                //ShowValueScript.enemyTextUpdate(7);

                //CHECKING IF THE AVERAGE FILTERED SIGNAL SURPASSES THE THRESHOLD
                if ((sum25/filtered25.Length) > staticPorts.ssvep_threshold){
                    print("ENEMY 25");
                    enemySelected = Convert.ToString(4);
                    enSel.text = Convert.ToString(4);
                }
                else if ((sum12/filtered19.Length) > staticPorts.ssvep_threshold){
                    print("ENEMY 19");
                    enemySelected = Convert.ToString(3);
                    enSel.text  = Convert.ToString(3);
                }
                else if ((sum12/filtered12.Length) > staticPorts.ssvep_threshold){
                    print(sum12/filtered12.Length);
                    print("ENEMY 12");
                    enemySelected = Convert.ToString(2);
                    enSel.text  = Convert.ToString(2);
                }
                else if ((sum5/filtered5.Length) > staticPorts.ssvep_threshold){
                    print(sum5/filtered5.Length);
                    print("ENEMY 5");
                    enemySelected = Convert.ToString(1);
                    enSel.text  = Convert.ToString(1);
                }
                else{
                    enemySelected = Convert.ToString(-1);
                    enSel.text  = Convert.ToString(-1);
                }
                //print("AVERAGE FILTERED "+sum /filtered.Length );
                */
                unprocessed_data = empty_data;
            }
            
            
            
        
        }
    }
