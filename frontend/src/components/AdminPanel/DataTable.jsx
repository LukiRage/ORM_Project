import React from 'react';
import {useEffect} from 'react';

const DataTable = ({ data, columns }) => {
  useEffect(() => {
    console.log('Data in DataTable:', data);
  }, [data]);
  
  return (
    <table>
      <thead>
        <tr>
          {columns.map((column, index) => (
            <th key={index}>{column.Header}</th>
          ))}
        </tr>
      </thead>
      <tbody>
        {data.length > 0 ? (
          data.map((row, index) => (
            <tr key={index}>
              {columns.map((column) => (
                <td key={`${index}-${column.accessor}`}>{row[column.accessor]}</td>
              ))}
            </tr>
          ))
        ) : (
          <tr>
            <td colSpan={columns.length}>No data</td>
          </tr>
        )}
      </tbody>
    </table>
  );
};

export default DataTable;
