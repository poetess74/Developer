package com.example.customwidget;

import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;

import android.Manifest;
import android.os.Bundle;
import android.os.Environment;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

import java.io.File;

public class MainActivity extends AppCompatActivity {
    private TextView        page;
    private Button          previous, next;
    private MyPictureView   pictureView;
    private int             index;
    private File[]          imageFiles;
    private String          imageName;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        ActivityCompat.requestPermissions(this, new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE}, MODE_PRIVATE);

        setTitle("간단 이미지 뷰어");
        init();
        setAction();
    }

    private void init() {
        previous = findViewById(R.id.prev);
        next = findViewById(R.id.next);
        page = findViewById(R.id.pageNum);
        pictureView = findViewById(R.id.picture);

        imageFiles = new File(Environment.getExternalStorageDirectory().getAbsolutePath() + "/Pictures").listFiles();
        imageName = imageFiles[0].toString();
        pictureView.setImagePath(imageName);
        page.setText(String.format("%d/%d", index + 1, imageFiles.length));
    }

    private void setAction() {
        previous.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                index = (index <= 0) ? imageFiles.length - 1 : --index;
                updateImageView();
            }
        });
        next.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                index = (index >= imageFiles.length - 1) ? index = 0 : ++index;
                updateImageView();
            }
        });
    }

    private void updateImageView() {
        page.setText(String.format("%d/%d", index + 1, imageFiles.length));
        imageName = imageFiles[index].toString();
        pictureView.setImagePath(imageName);
        pictureView.invalidate();
    }
}