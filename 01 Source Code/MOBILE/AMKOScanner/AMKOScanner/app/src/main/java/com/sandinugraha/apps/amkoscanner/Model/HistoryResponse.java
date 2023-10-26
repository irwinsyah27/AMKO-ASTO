package com.sandinugraha.apps.amkoscanner.Model;

import com.google.gson.annotations.SerializedName;

import java.util.List;

/**
 * Created by sandinugraha on 26/01/18.
 */

public class HistoryResponse {
    @SerializedName("status")
    private String status;
    @SerializedName("data")
    private List<History> data;

    public String getStatus() {
        return status;
    }

    public void setStatus(String status) {
        this.status = status;
    }

    public List<History> getData() {
        return data;
    }

    public void setData(List<History> data) {
        this.data = data;
    }
}
