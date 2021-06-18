package com.example.moviegallery;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Gallery;
import android.widget.ImageView;

public class MainActivity extends AppCompatActivity {
    Gallery gallery;
    MyGalleryAdapter adapter;
    Integer[] posterID;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        setTitle("갤러리 영화 포스터");
        init();
    }

    private void init() {
        gallery = findViewById(R.id.gallery);
        posterID = new Integer[35];
        posterID[0] = R.drawable.mov01;
        posterID[1] = R.drawable.mov02;
        posterID[2] = R.drawable.mov03;
        posterID[3] = R.drawable.mov04;
        posterID[4] = R.drawable.mov05;
        posterID[5] = R.drawable.mov06;
        posterID[6] = R.drawable.mov07;
        posterID[7] = R.drawable.mov08;
        posterID[8] = R.drawable.mov09;
        posterID[9] = R.drawable.mov10;
        posterID[10] = R.drawable.mov11;
        posterID[11] = R.drawable.mov12;
        posterID[12] = R.drawable.mov13;
        posterID[13] = R.drawable.mov14;
        posterID[14] = R.drawable.mov15;
        posterID[15] = R.drawable.mov16;
        posterID[16] = R.drawable.mov17;
        posterID[17] = R.drawable.mov18;
        posterID[18] = R.drawable.mov19;
        posterID[19] = R.drawable.mov20;
        posterID[20] = R.drawable.mov21;
        posterID[21] = R.drawable.mov22;
        posterID[22] = R.drawable.mov23;
        posterID[23] = R.drawable.mov24;
        posterID[24] = R.drawable.mov25;
        posterID[25] = R.drawable.mov26;
        posterID[26] = R.drawable.mov27;
        posterID[27] = R.drawable.mov28;
        posterID[28] = R.drawable.mov29;
        posterID[29] = R.drawable.mov30;
        posterID[30] = R.drawable.mov31;
        posterID[31] = R.drawable.mov32;
        posterID[32] = R.drawable.mov33;
        posterID[33] = R.drawable.mov34;
        posterID[34] = R.drawable.mov35;
        adapter = new MyGalleryAdapter(getApplicationContext());
        gallery.setAdapter(adapter);
    }

    private class MyGalleryAdapter extends BaseAdapter {
        Context context;

        public MyGalleryAdapter(Context context) {
            this.context = context;
        }

        @Override
        public int getCount() {
            return posterID.length;
        }

        @Override
        public Object getItem(int position) {
            return null;
        }

        @Override
        public long getItemId(int position) {
            return 0;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            ImageView imageView = new ImageView(context);
            imageView.setLayoutParams(new Gallery.LayoutParams(200, 300));
            imageView.setScaleType(ImageView.ScaleType.FIT_CENTER);
            imageView.setPadding(5, 5, 5, 5);
            imageView.setImageResource(posterID[position]);

            imageView.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    ImageView ivPoster = findViewById(R.id.ivPoster);
                    ivPoster.setScaleType(ImageView.ScaleType.FIT_CENTER);
                    ivPoster.setImageResource(posterID[position]);
                }
            });
            return imageView;
        }
    }
}