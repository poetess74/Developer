package com.example.sdcardio;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;

import android.Manifest;
import android.os.Bundle;
import android.os.Environment;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import java.io.FileInputStream;
import java.io.IOException;

public class MainActivity extends AppCompatActivity {
    private Button   read;
    private EditText output;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ActivityCompat.requestPermissions(this, new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE}, MODE_PRIVATE);

        init();
        setAction();
    }

    private void init() {
        read = findViewById(R.id.read);
        output = findViewById(R.id.output);
    }

    private void setAction() {
        read.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                try {
                    FileInputStream input = new FileInputStream(Environment.getExternalStorageDirectory().getAbsolutePath() + "/file.txt");
                    byte[] txt = new byte[input.available()];
                    input.read(txt);
                    output.setText(new String(txt));
                    input.close();
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }
        });
    }
}