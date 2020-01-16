//
//  ViewController.m
//  CountDown&StopWatch
//
//  Created by HM, MH on 2015. 2. 1..
//  Copyright (c) 2015년 HM, MH. All rights reserved.
//

#import "ViewController.h"

@interface ViewController()
@property (nonatomic, strong) NSTimer* timer;
@property (nonatomic) CFAbsoluteTime startTime;
@property (nonatomic) CFAbsoluteTime countdownTime;
@property (nonatomic) CFAbsoluteTime lastCountdownTime;
@property (nonatomic) BOOL isStopped;


@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];

    // Do any additional setup after loading the view.
    [stpHour setIntValue:0];
    [stpMinute setIntValue:1];
    [stpSecond setIntValue:0];
    
    [self setTimeLabel:[self getCurrentSetTime]];

    self.isStopped = NO;
}

- (void)setRepresentedObject:(id)representedObject {
    [super setRepresentedObject:representedObject];

    // Update the view, if already loaded.
}

- (double)getCurrentSetTime {
    int h = [stpHour intValue];
    int m = [stpMinute intValue];
    int s = [stpSecond intValue];
    
    return s + m * 60 + h * 3600;
}

- (void)setTimeLabel:(double)time {
    long secs = (long)time;
    long msecs = (long)((time - secs) * 1000);
    /*
     diff 가 5.388933라고 했을 때
     secs 는 (long)(5.388933) ==> 5가 된다.
     msecs 는 (long)((5.388933 - 5<<secs는 5니까>>) * 1000) ==> 388이 된다. 곱하기 1000을 하면 388.933이 되고,
     long으로 바꿔서 소수점 아래를 날려버렸기 때문에 그렇다.
     */
    
    long h = secs / 3600;
    long m = (secs - h * 3600) / 60;
    long s = secs - m * 60 - h * 3600;
    
    [lblHMS setStringValue:[NSString stringWithFormat:@"%02ld:%02ld:%02ld", h, m, s]];
    [lblMsecs setStringValue:[NSString stringWithFormat:@".%03ld", msecs]];
}

- (void)onTime {
    CFAbsoluteTime diff = CFAbsoluteTimeGetCurrent() - self.startTime;

    diff = self.countdownTime - diff;
    
    self.lastCountdownTime = diff;
    
    if (diff <= 0) {
        [self setTimeLabel:0];
        [self.timer invalidate];
        self.timer = nil;
        

        [btnStart setEnabled:NO];
        [stpHour setEnabled:NO];
        [stpMinute setEnabled:NO];
        [stpSecond setEnabled:NO];
        
        [btnReset setEnabled:YES];

        self.isStopped = YES;
        [btnReset setTitle:@"Reset"];
        return;
    }
    
    [self setTimeLabel:diff];
}

- (IBAction)onStartButtonPress:(id)sender {
    if (self.isStopped) {
        self.countdownTime = self.lastCountdownTime;
        self.isStopped = NO;
    } else {
        self.countdownTime = [self getCurrentSetTime];
    }
    self.startTime = CFAbsoluteTimeGetCurrent();
    self.timer = [NSTimer scheduledTimerWithTimeInterval:0.01f
                                                  target:self
                                                selector:@selector(onTime)
                                                userInfo:nil
                                                 repeats:YES];
    
    [btnStart setEnabled:NO];
    [stpHour setEnabled:NO];
    [stpMinute setEnabled:NO];
    [stpSecond setEnabled:NO];
    
    [btnReset setEnabled:YES];
    [btnReset setTitle:@"Stop"];
}

- (IBAction)onResetButtonPress:(id)sender {
    if (self.isStopped) {
        self.isStopped = NO;
        
        [btnStart setEnabled:YES];
        [stpHour setEnabled:YES];
        [stpMinute setEnabled:YES];
        [stpSecond setEnabled:YES];
        
        [btnReset setEnabled:NO];
        
        [self setTimeLabel:[self getCurrentSetTime]];
    } else {
        [self.timer invalidate];
        self.timer = nil;
        
        self.isStopped = YES;
        
        [btnStart setEnabled:YES];
        
        [btnReset setTitle:@"Reset"];
    }
}


- (IBAction)onHourStepper:(id)sender {
    [self setTimeLabel:[self getCurrentSetTime]];
}

- (IBAction)onMinuteStepper:(id)sender {
    [self setTimeLabel:[self getCurrentSetTime]];
}

- (IBAction)onSecondStepper:(id)sender {
    [self setTimeLabel:[self getCurrentSetTime]];
}

@end
