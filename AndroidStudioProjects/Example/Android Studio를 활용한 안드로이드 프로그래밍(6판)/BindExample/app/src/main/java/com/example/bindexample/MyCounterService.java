package com.example.bindexample;

import android.app.Service;
import android.content.Intent;
import android.os.Handler;
import android.os.IBinder;
import android.os.RemoteException;
import android.speech.tts.TextToSpeech;
import android.util.Log;
import android.widget.Toast;

import java.util.Locale;

public class MyCounterService extends Service {
    private boolean isStop;
    private int count;
    private TextToSpeech tts;
    private boolean ttsNull;
    public MyCounterService() { }

    IMyCounterService.Stub binder = new IMyCounterService.Stub() {
        @Override
        public int getCount() throws RemoteException {
            return count;
        }
    };

    @Override
    public void onCreate() {
        super.onCreate();
        Intent checkIntent = new Intent();
        checkIntent.setAction(TextToSpeech.Engine.ACTION_CHECK_TTS_DATA);
        tts = new TextToSpeech(getApplicationContext(), new TextToSpeech.OnInitListener() {
            @Override
            public void onInit(int status) {
                if(status == TextToSpeech.SUCCESS) {
                    int result = tts.setLanguage(Locale.KOREA);
                    if(result == TextToSpeech.LANG_MISSING_DATA || result == TextToSpeech.LANG_NOT_SUPPORTED) {
                        ttsNull = true;
                        Toast.makeText(getApplicationContext(), "이 언어는 지원하지 않습니다. ", Toast.LENGTH_SHORT).show();
                    }
                } else {
                    ttsNull = true;
                }
            }
        });

        Thread counter = new Thread(new Counter());
        counter.start();
    }

    @Override
    public void onDestroy() {
        super.onDestroy();
        isStop = true;
    }

    @Override
    public boolean onUnbind(Intent intent) {
        isStop = true;
        return super.onUnbind(intent);
    }

    @Override
    public IBinder onBind(Intent intent) {
        return binder;
    }

    private class Counter implements Runnable {
        private Handler handler = new Handler();

        @Override
        public void run() {
            for (count = 0; count < 10; count++) {
                if(isStop) break;
                handler.post(new Runnable() {
                    @Override
                    public void run() {
                        Log.println(Log.DEBUG, "BIND_EX", String.format("Count: %d", count));
                    }
                });
                try {
                    Thread.sleep(1000);
                } catch (InterruptedException e) {
                    e.printStackTrace();
                }
            }
            handler.post(new Runnable() {
                @Override
                public void run() {
                    if(!ttsNull) {
                        Toast.makeText(getApplicationContext(), "서비스가 종료되었습니다. ", Toast.LENGTH_SHORT).show();
                        tts.speak("라면이 다 익었습니다. ", TextToSpeech.QUEUE_ADD, null);
                    } else {
                        Log.println(Log.DEBUG, "BIND_EX", "Terminated service.");
                        Toast.makeText(getApplicationContext(), "라면이 다 익었습니다. ", Toast.LENGTH_LONG).show();
                    }
                }
            });
        }
    }
}