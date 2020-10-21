//using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

// Remember to add the following using statemnt to the top of your class. This will give you access to all of Odin's attributes.
//using Sirenix.OdinInspector;

namespace VrGamesDev
{


    /// #ignore
    public enum ENUM_DelimitedSeparatedFiles
    {
        CSV_ByComma,
        PSV_ByPipe,
        TSV_ByTab

    }



    [System.Serializable]
    public class VRG_DataFromRow
    {
        [SerializeField] private string[] m_Data;

        public VRG_DataFromRow(string[] valueLocal)
        {
            this.m_Data = valueLocal;
        }
    }

    public class VRG_CSV : VRG_Base
    {


        [SerializeField] private ENUM_DelimitedSeparatedFiles m_DelimitedSeparatedFiles;



        [Header("From: Components")]
        [Tooltip("Reference from CSV file")]
        [SerializeField] private TextAsset m_LocalizationFile;



        [Tooltip("It defines line Separator character")]
        //[SerializeField]
        private char m_lineSeparator = '\n';

        [Tooltip("It defines field Separator character")]
        //[SerializeField]
        private char m_Separator = ',';


        [SerializeField] private string[] m_Header;


        //[SerializeField] private List<VRG_DataFromRow> m_Data;
        //[SerializeField] private List<string[]> m_Data;



        // Use this for initialization use new to get 
        private new void Start()
        {
            switch (this.m_DelimitedSeparatedFiles)
            {
                case ENUM_DelimitedSeparatedFiles.CSV_ByComma:
                    this.m_Separator = ',';
                    break;

                case ENUM_DelimitedSeparatedFiles.PSV_ByPipe:
                    this.m_Separator = '|';
                    break;

                case ENUM_DelimitedSeparatedFiles.TSV_ByTab:
                    this.m_Separator = '\t';
                    break;
            }


            string[] sLines = this.m_LocalizationFile.text.Split(this.m_lineSeparator);

            print(sLines.Length);

            int i = 0;
            foreach (string child in sLines)
            {
                print(child);
                if (i ==  0)
                {
                    m_Header = sLines[i].Split(this.m_Separator);
                }
                else
                {
                    /*
                    string[] childRawData = child.Split(this.m_Separator);


                    
                    //VRG_DataFromRow DataFromRow = new VRG_DataFromRow(childRawData);
                    //this.m_Data.Add(DataFromRow);
                    
                    this.m_Data.Add(childRawData);                    
                    */

                }
                i++;
            }




            // start your parent from VRG_Base
            base.Start();
        }



    }
}