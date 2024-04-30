import pickle
import sys
import pandas as pd
import predprocessing.PayloadDataset
from io import StringIO

if len(sys.argv) == 3:
    data_prediction = sys.argv[1]
    model = sys.argv[2]

    with open(data_prediction, 'rb') as file:
        loaded_data = pickle.load(file)

    while True:
        inn = input()

        column = [
            'date_time', 'source_port', 'source_mac_address', 'source_ip_address', 'destination_port',
            'destination_mac_address',
            'destination_ip_address', 'sequence_number', 'acknowledgement_number', 'payload_tcp', 'transaction_id',
            'protocol_id',
            'len_remaining_package', 'device_id', 'request', 'address_register', 'count_byte', 'count_registers',
            'payload_bytes',
            'function', 'anomaly']

        df = pd.read_csv(StringIO(inn), index_col='date_time', parse_dates=True, header=None, names=column,
                         dtype={'destination_mac_address': object, 'source_mac_address': object})

        print(loaded_data.transform(df))
