package com.example.internalfileio;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.Toast;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class MainActivity extends AppCompatActivity {
    private Button read, write;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        init();
        setAction();
    }

    private void init() {
        read = findViewById(R.id.readJournal);
        write = findViewById(R.id.writeJournal);
    }

    private void setAction() {
        write.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                try {
                    FileOutputStream output = openFileOutput("file.txt", Context.MODE_PRIVATE);
                    final String id = "13주차 파일입출력/김형민";
                    output.write(id.getBytes());
                    output.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        });

        read.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                try {
                    FileInputStream input = openFileInput("file.txt");
                    byte[] txt = new byte[30];
                    input.read(txt);
                    String text = new String(txt);
                    Toast.makeText(getApplicationContext(), text, Toast.LENGTH_SHORT).show();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        });
    }
}