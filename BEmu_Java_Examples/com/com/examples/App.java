//------------------------------------------------------------------------------
// <copyright project="BEmu_Java_Examples" file="/BEmu_Java_Examples/com/com/examples/App.java" company="Jordan Robinson">
//     Copyright (c) 2013 Jordan Robinson. All rights reserved.
//
//     The use of this software is governed by the Microsoft Public License
//     which is included with this distribution.
// </copyright>
//------------------------------------------------------------------------------

package com.examples;

import java.util.Scanner;

public class App 
{
    public static void main( String[] args ) throws Exception
    {
        System.out.println("Bloomberg API Emulator Examples");
        System.out.println("http://bemu.codeplex.com/");
        System.out.println("By: Robinson664");
        System.out.println();

        System.out.println("To send a historical data request, push 1");
        System.out.println("To send a intraday bar data request, push 2");
        System.out.println("To send a intraday tick data request, push 3");
        System.out.println("To send a market data request, push 4");
        System.out.println("To send a reference data request, push 5");
        
        Scanner scan = new Scanner(System.in);
        int input = scan.nextInt();
        
        System.out.println();
        System.out.println();
        boolean informationReturned = true;
                
        switch(input)
        {
        	case 1:
        		RunHistoricalDataRequest.RunExample();
        		break;
        	case 2:
        		RunIntradayBarDataRequest.RunExample();
        		break;
        	case 3:
        		RunIntradayTickDataRequest.RunExample();
        		break;
        	case 4:
        		RunMarketDataSubscription.RunExample();
        		break;
        	case 5:
        		RunReferenceDataRequest.RunExample();
        		break;
        	default:
        		informationReturned = false;
        		break;
        }
        
        if (informationReturned)
        {
        	System.out.println();
        	System.out.println("Please note that the data in this request is completely random: it is not real data.");
        	System.out.println("Do not make any trading or investment decisions using the data shown here.");
        }

    	System.out.println();
    	System.out.println("Press any key to exit");
    	System.in.skip(System.in.available());
    	System.in.read();
        
    }
}
