package com.example.contentprovider;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;

import android.Manifest;
import android.database.Cursor;
import android.os.Bundle;
import android.provider.CallLog;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import java.text.SimpleDateFormat;
import java.util.Date;

public class MainActivity extends AppCompatActivity {
    Button    getCallList;
    EditText  showCalls;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("Content Provider");
        ActivityCompat.requestPermissions(this, new String[] {Manifest.permission.READ_CALL_LOG}, MODE_PRIVATE);

        init();
        setAction();
    }

    private void init() {
        getCallList = findViewById(R.id.btnCall);
        showCalls = findViewById(R.id.edtCall);
    }

    private void setAction() {
        getCallList.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showCalls.setText(getCallHistory());
            }
        });
    }

    private String getCallHistory() {
        String[] callSet = new String[] {
            CallLog.Calls.DATE, CallLog.Calls.TYPE, CallLog.Calls.NUMBER, CallLog.Calls.DURATION
        };
        Cursor cursor = getContentResolver().query(CallLog.Calls.CONTENT_URI, callSet, null, null, null);
        if(cursor == null || cursor.getCount() == 0) {
            return "통화내역이 없습니다.";
        }

        StringBuffer callBuff = new StringBuffer();
        callBuff.append("\n날짜 | 구분 | 전화번호 | 통화시간\n\n");
        cursor.moveToFirst();
        do {
            long callDate = cursor.getLong(0);
            SimpleDateFormat dateFormat = new SimpleDateFormat("EEEE, MMMM d");
            String date = dateFormat.format(new Date(callDate));
            callBuff.append(date + " : ");
            callBuff.append(cursor.getInt(1) == CallLog.Calls.INCOMING_TYPE ? "착신 : " : "발신 : ");
            callBuff.append(cursor.getString(2) + " : ");
            callBuff.append(cursor.getString(3) + " 초\n");
        } while (cursor.moveToNext());

        cursor.close();
        return callBuff.toString();
    }
}