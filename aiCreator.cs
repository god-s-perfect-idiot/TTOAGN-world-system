using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiCreator : MonoBehaviour
{

   static char[] pref = {'A','K','T','H','N','M','S'};

   static char[] cons = {'b','c','f','h','k','m','n','r','s','t','v','w','y'};
   static char[] vowels = {'a','i','o','u'};

    // Start is called before the first frame update
    void Start()
    {
          Debug.Log(weebNameGenerator());

    }

    string weebNameGenerator(){

      System.Random r = new System.Random();
      int length = r.Next(3,9);
      if(length%2!=0){
        length += 1;
      }

      string name="";
      int st = r.Next(0,7);
      name += pref[st];
      int bf = 1;

      if(pref[st] == 'S' || pref[st] == 'K'){

        int dec = r.Next(0,8);
        if(dec == 7){
            name += 'h';
        }
      }

      if(pref[st] != 'A'){
          bf = 0;
      }


      for(int i=1-bf;i<length;i++){
        if(i%2==0){
          int indx = r.Next(0,13);
          name += cons[indx];
          if(cons[indx] == 's' || cons[indx] == 'k' || cons[indx] == 'c'){

            int dec = r.Next(0,2);
            if(dec == 1){
                name += 'h';
            }

          }
        }
        else{
          int indx = r.Next(0,4);
          name += vowels[indx];
        }
      }

      return name;

    }

}
