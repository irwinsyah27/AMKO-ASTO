package com.sandinugraha.apps.amkoscanner.Model;

import com.google.gson.annotations.SerializedName;

import java.util.List;

/**
 * Created by sandinugraha on 26/01/18.
 */

public class AssetResponse {
    @SerializedName("status")
    private String status;
    @SerializedName("data")
    private Asset data;

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public Asset getData() {
        return data;
    }

    public void setData(Asset data) {
        this.data = data;
    }
}
