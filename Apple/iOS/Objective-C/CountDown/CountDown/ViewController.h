//
//  ViewController.h
//  CountDown&StopWatch
//
//  Created by HM, MH on 2015. 2. 1..
//  Copyright (c) 2015년 HM, MH. All rights reserved.
//

#import <Cocoa/Cocoa.h>

@interface ViewController : NSViewController {
    IBOutlet NSTextField* lblHMS;
    IBOutlet NSTextField* lblMsecs;
    IBOutlet NSStepper* stpHour;
    IBOutlet NSStepper* stpMinute;
    IBOutlet NSStepper* stpSecond;
    IBOutlet NSButton* btnStart;
    IBOutlet NSButton* btnReset;
}

- (IBAction)onStartButtonPress:(id)sender;
- (IBAction)onResetButtonPress:(id)sender;
- (IBAction)onHourStepper:(id)sender;
- (IBAction)onMinuteStepper:(id)sender;
- (IBAction)onSecondStepper:(id)sender;

@end

