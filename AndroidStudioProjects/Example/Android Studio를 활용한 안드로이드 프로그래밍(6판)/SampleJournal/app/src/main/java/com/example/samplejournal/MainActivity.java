package com.example.samplejournal;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Toast;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.Calendar;

public class MainActivity extends AppCompatActivity {
    private DatePicker date;
    private EditText   journal;
    private Button     write;
    private String     fileName;

    private int year, month, day;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("간단 일기장");
        init();
        setAction();
        startService();
    }

    private void init() {
        date = findViewById(R.id.date);
        journal = findViewById(R.id.editor);
        write = findViewById(R.id.submit);

        Calendar calendar = Calendar.getInstance();
        year = calendar.get(Calendar.YEAR);
        month = calendar.get(Calendar.MONTH);
        day = calendar.get(Calendar.DAY_OF_MONTH);
    }

    private void startService() {
        fileName = String.format("%s_%s_%s.txt", year, month + 1, day);
        journal.setText(readDiary(fileName));
    }

    private void setAction() {
        date.init(year, month, day, new DatePicker.OnDateChangedListener() {
            @Override
            public void onDateChanged(DatePicker datePicker, int year, int monthOfYear, int dayOfMonth) {
                fileName = String.format("%s_%s_%s.txt", year, monthOfYear + 1, dayOfMonth);
                String text = readDiary(fileName);
                journal.setText(text);
                write.setEnabled(true);
            }
        });

        write.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                try {
                    FileOutputStream output = openFileOutput(fileName, Context.MODE_PRIVATE);
                    String string = journal.getText().toString();
                    output.write(string.getBytes());
                    output.close();
                    Toast.makeText(getApplicationContext(), String.format("%s 이(가) 저장됨", fileName), Toast.LENGTH_SHORT).show();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        });
    }

    private String readDiary(String fileName) {
        String diaryStr = null;
        FileInputStream input;
        try {
            input = openFileInput(fileName);
            byte[] txt = new byte[500];
            input.read(txt);
            input.close();
            diaryStr = (new String(txt)).trim();
            write.setText("일기 수정");
        } catch (IOException e) {
            journal.setHint("일기 없음");
            write.setText("새로 작성");
        }
        return diaryStr;
    }
}